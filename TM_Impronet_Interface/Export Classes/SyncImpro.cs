using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TM_Impronet_Interface.Classes;
using TM_Impronet_Interface.Properties;

namespace TM_Impronet_Interface.Export_Classes
{
    public static class SyncImpro
    {
        
        public static event EventHandler OnProgressHandler;

        public static void OnProgress(int progress = 0, int totalRecords = 0, string status = "")
        {
            try
            {
                var onProgressHandler = OnProgressHandler;
                if (onProgressHandler == null)
                    return;
                var progressEventArgs = new ProgressEventArgs { Progress = progress, TotalRecords = totalRecords, Status = status };
                onProgressHandler(null, progressEventArgs);
            }
            catch
            {
                //Do nothing
            }
        }

        public static void StartSync()
        {
            var tmpDataAccess = new TmpDataAccess();
            var improDataAccess = new ImproDataAccess();

        string departments;
            if (!Settings.Default.SyncAllDepartments)
            {
                var deptObj = Settings.Default.SelectedDepartments;
                if (deptObj == null)
                    return;

                departments =
                    deptObj.Cast<string>().Aggregate("", (current, dept) => current + $"'{dept}',").TrimEnd(',');
            }
            else
            {
                var departmentList = tmpDataAccess.GetDepartments();
                if (departmentList == null)
                    return;

                departments = departmentList.Aggregate("", (current, dept) => current + $"'{dept.Id}',")
                    .TrimEnd(',');
            }

            var errors = new List<string>();
            var newEmployees = new List<string>();

            var improDepartments = improDataAccess.GetDepartments();
            if (improDepartments == null)
                return;
            var tmpDepartments = tmpDataAccess.GetDepartments();
            if (tmpDepartments == null)
                return;
            var improCompanies = improDataAccess.GetImproCompanies();
            var tmpCompanies = tmpDataAccess.GetTmpCompanies();
            var companies = improCompanies.Where(comp => tmpCompanies.All(i => i.Code != comp.Code));

            OnProgress(0, 0, @"Running Company Sync");
            var comps = companies as Company[] ?? companies.ToArray();

            //Determine if Companies already exist
            var counter = 0;
            var iterationCount = comps.Length;
            foreach (var comp in comps)
            {
                //Create new company in TMP
                tmpDataAccess.CreateTmpCompany(new Company {Code = comp.Code, Description = "DEFAULT"});
                OnProgress(counter++, iterationCount);
            }

            var iDepartments = improDepartments.Where(dept => tmpDepartments.All(i => i.Id != dept.Id));
            OnProgress(0, 0, @"Running Department Sync");
            var depts = iDepartments as Department[] ?? iDepartments.ToArray();

            //Determine if Departments already exist
            counter = 0;
            iterationCount = depts.Length;
            foreach (var dept in depts)
            {
                //Create new department in TMP
                tmpDataAccess.CreateTmpDepartment(new Department {Id = dept.Id, Name = dept.Name});
                OnProgress(counter++, iterationCount);
            }

            var improEmployees = improDataAccess.GetImproEmployees(departments);
            if (improEmployees == null)
                return;
            var tmpEmployees = tmpDataAccess.GetTmpEmployees();
            if (tmpEmployees == null)
                return;

            //Determine if Employees already exist
            OnProgress(0, 0, @"Running Employee Sync");
            var enumerable = improEmployees as Employee[] ?? improEmployees.ToArray();
            var employees1 = tmpEmployees;
            var iEmpl = enumerable.Where(empl => employees1.All(i => i.CardNumber != empl.CardNumber));
            var empls = iEmpl as Employee[] ?? iEmpl.ToArray();

            counter = 0;
            iterationCount = empls.Length;
            foreach (var empl in empls)
            {
                //Create new employee in TMP                
                tmpDataAccess.CreateTmpEmployee(empl);
                tmpDataAccess.CreateTmpCardNumber(empl);
                newEmployees.Add($"Employee No: {empl.EmployeeeNo}, Name: {empl.Name}, Suname: {empl.LastName}");
                OnProgress(counter++, iterationCount);
            }

            //Refresh after create
            improEmployees = improDataAccess.GetImproEmployees(departments);
            if (improEmployees == null)
                return;
            tmpEmployees = tmpDataAccess.GetTmpEmployees();
            if (tmpEmployees == null)
                return;

            OnProgress(0, 0, @"Running Existing Employee Sync");
            var tmpEmployees1 = tmpEmployees as IList<Employee> ?? tmpEmployees.ToList();
            var employees = tmpEmployees as IList<Employee> ?? tmpEmployees1.ToList();
            var syncedEmployees = new List<string>();

            counter = 0;
            iterationCount = enumerable.Length;
            foreach (var improEmployee in enumerable)
            {
                foreach (var tmpEmployee in employees)
                {
                    if (improEmployee.CardNumber != tmpEmployee.CardNumber) continue;

                    if (improEmployee.DepartmentNo != tmpEmployee.DepartmentNo ||
                        improEmployee.Suspended != tmpEmployee.Suspended ||
                        improEmployee.EmployeeeNo != tmpEmployee.EmployeeeNo)
                    {

                        try
                        {
                            //UPDATE ALL TABLES THAT USE EMPLOYEE NUMBER IF IT GETS UPDATED
                            if (improEmployee.EmployeeeNo != tmpEmployee.EmployeeeNo &&
                                Settings.Default.UpdateEmployeeNumber)
                            {
                                syncedEmployees.Add($"{DateTime.Now}: {tmpEmployee.EmployeeeNo} --> {improEmployee.EmployeeeNo}");
                                var employee = tmpDataAccess.GetTmpEmployee(improEmployee.EmployeeeNo);
                                if (employee != null)
                                {
                                    //Check if employees are the same employee
                                    if (employee.IdNumber == tmpEmployee.IdNumber)
                                    {
                                        RenameTmpEmployeeNumber(tmpEmployee.EmployeeeNo, improEmployee.EmployeeeNo);                                        
                                        continue;
                                    }

                                    //Employee number already exists in tmp -- Rename old employee
                                    RenameTmpEmployeeNumber(tmpEmployee.EmployeeeNo,
                                        tmpEmployee.EmployeeeNo + "_cd");
                                    tmpDataAccess.EditTmpEmp_EmpNo(tmpEmployee.EmployeeeNo, tmpEmployee.EmployeeeNo + "_cd");
                                }

                                RenameTmpEmployeeNumber(tmpEmployee.EmployeeeNo, improEmployee.EmployeeeNo);
                                tmpDataAccess.EditTmpEmp_EmpNo(tmpEmployee.EmployeeeNo,
                                    improEmployee.EmployeeeNo);
                            }
                        }
                        catch (Exception e)
                        {
                            errors.Add(e.ToString());
                        }
                    }
                    Application.DoEvents();
                }
                OnProgress(counter++, iterationCount);
            }

            if (errors.Count > 0)
            {
                File.AppendAllLines("SyncErrors.log", errors);
            }
            File.AppendAllLines("EmployeesChanged.log", syncedEmployees);
            OnProgress(100, 100, errors.Any() ? "Completed with errors" : @"Done");

            if (!Settings.Default.EnableEmail) return;
            {
                if (newEmployees.Count <= 0) return;
                var html = "New employees have been added to Time Manager Platinum:\n\n";
                html = newEmployees.Aggregate(html, (current, newEmployee) => current + (newEmployee + "\n"));
                html += "\nKind Regards\nThe TMP Team";
                EmailSending.Send_Email(GetSendToEmailAddresses(), Settings.Default.EmailAddress, "New Employees Added to Time Manager Platinum", html);
            }
        }

        private static IEnumerable<string> GetSendToEmailAddresses()
        {
            var addresses = new List<string>();
            if (!string.IsNullOrEmpty(Settings.Default.ToEmailAddress))
                addresses.Add(Settings.Default.ToEmailAddress);
            if (!string.IsNullOrEmpty(Settings.Default.ToEmailAddress2))
                addresses.Add(Settings.Default.ToEmailAddress2);
            if (!string.IsNullOrEmpty(Settings.Default.ToEmailAddress3))
                addresses.Add(Settings.Default.ToEmailAddress3);
            if (!string.IsNullOrEmpty(Settings.Default.ToEmailAddress4))
                addresses.Add(Settings.Default.ToEmailAddress4);
            if (!string.IsNullOrEmpty(Settings.Default.ToEmailAddress5))
                addresses.Add(Settings.Default.ToEmailAddress5);
            if (!string.IsNullOrEmpty(Settings.Default.ToEmailAddress6))
                addresses.Add(Settings.Default.ToEmailAddress6);
            return addresses;
        }

        private static void RenameTmpEmployeeNumber(string tmpEmployeeNumber, string improEmployeeNumber)
        {
            var tmpDataAccess = new TmpDataAccess();

            tmpDataAccess.EditTmpAttachments(tmpEmployeeNumber,improEmployeeNumber);
            tmpDataAccess.EditTmpButton( tmpEmployeeNumber,improEmployeeNumber);
            tmpDataAccess.EditTmpClockD( tmpEmployeeNumber,improEmployeeNumber);
            tmpDataAccess.EditTmpClocking( tmpEmployeeNumber,improEmployeeNumber);
            tmpDataAccess.EditTmpEmployeeDisciplinary(tmpEmployeeNumber,improEmployeeNumber);
            tmpDataAccess.EditTmpEmployeeLeaveInfo(tmpEmployeeNumber,improEmployeeNumber);
            tmpDataAccess.EditTmpEmployeeLicenses(tmpEmployeeNumber,improEmployeeNumber);
            tmpDataAccess.EditTmpEmployeeLimitations(tmpEmployeeNumber,improEmployeeNumber);
            tmpDataAccess.EditTmpFlexiTime( tmpEmployeeNumber,improEmployeeNumber);
            tmpDataAccess.EditTmpHoursSummary(tmpEmployeeNumber,improEmployeeNumber);
            tmpDataAccess.EditTmpLeaveRecords(tmpEmployeeNumber,improEmployeeNumber);
            tmpDataAccess.EditTmpOldLeaveRecords(tmpEmployeeNumber,improEmployeeNumber);
            tmpDataAccess.EditTmpPhotos( tmpEmployeeNumber,improEmployeeNumber);
            tmpDataAccess.EditTmpTrainingRecords(tmpEmployeeNumber,improEmployeeNumber);
            tmpDataAccess.EditTmpWorkPatternSchedules(tmpEmployeeNumber,improEmployeeNumber);
        }
    }
}
