using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using TM_Impronet_Interface.Properties;

namespace TM_Impronet_Interface.Classes
{
    public class TmpDataAccess
    {
        public FbConnection Connection { get; set; }
        public FbCommand Command { get; set; }

        public TmpDataAccess()
        {
            Connection = GetTmpConnectionObject();
            Command = new FbCommand();
        }

        private FbConnection GetTmpConnectionObject()
        {
            var connectionString =
                "User=SYSDBA;" +
                "Password=masterkey;" +
                "Database=" + Settings.Default.TMPDatabaseLocation + ";" +
                "DataSource=localhost;" +
                "Port=3050;" +
                "Dialect=3;" +
                "Charset=NONE;" +
                "Role=;" +
                "Connection lifetime=15;" +
                "Pooling=true;" +
                "Packet Size=8192;" +
                "ServerType=0";
            return new FbConnection(connectionString);
        }

        public void TestConnection()
        {
            try
            {                               
                Connection.Open();
            }
            finally
            {
                Connection.Close();
            }
        }

        public List<CostCentre> GetCostCentres()
        {
            try
            {
                Command = new FbCommand();
                Connection.Open();

                var myTransaction = Connection.BeginTransaction();
                Command = new FbCommand
                {
                    Connection = Connection,
                    Transaction = myTransaction,
                    CommandText = "SELECT * FROM CCENTRES ORDER BY CODE"
                };

                var myReader = Command.ExecuteReader();

                var costCentres = new List<CostCentre>();
                while (myReader.Read())
                {
                    var cc = new CostCentre
                    {
                        Code = myReader["CODE"].ToString(),
                        Description = myReader["DESCRIPTION"].ToString()
                    };
                    costCentres.Add(cc);
                }

                return costCentres;
            }
            finally
            {
                Connection.Close();
            }
        }

        public List<Department> GetDepartments()
        {
            try
            {
                Command = new FbCommand();
                Connection.Open();

                var myTransaction = Connection.BeginTransaction();
                var myCommand = new FbCommand
                {
                    Connection = Connection,
                    Transaction = myTransaction,
                    CommandText = "SELECT * FROM DEPARTMENTS ORDER BY CODE"
                };

                var myReader = myCommand.ExecuteReader();

                var departments = new List<Department>();
                while (myReader.Read())
                {
                    var dep = new Department
                    {
                        Id = myReader["CODE"].ToString(),
                        Name = myReader["DESCRIPTION"].ToString()
                    };
                    departments.Add(dep);
                }

                return departments;
            }
            finally
            {
                Connection.Close();
            }
        }

        public List<Company> GetCompanies()
        {
            try
            {
                Command = new FbCommand();
                Connection.Open();

                var myTransaction = Connection.BeginTransaction();
                var myCommand = new FbCommand
                {
                    Connection = Connection,
                    Transaction = myTransaction,
                    CommandText = "SELECT * FROM COMPANIES ORDER BY CODE"
                };

                var myReader = myCommand.ExecuteReader();

                var companies = new List<Company>();
                while (myReader.Read())
                {
                    var company = new Company
                    {
                        Code = myReader["CODE"].ToString(),
                        Description = myReader["DESCRIPTION"].ToString()
                    };
                    companies.Add(company);
                }

                return companies;
            }
            finally
            {
                Connection.Close();
            }
        }        

        public Employee GetTmpEmployee(string employeeNumber)
        {
            try
            {
                Command = new FbCommand();
                Command.Connection = Connection;
                Connection.Open();

                var transaction = Connection.BeginTransaction();
                Command.Transaction = transaction;

                Command.CommandText = "SELECT a.EMP_NO, a.DEPARTMENT, a.DISCHARGED, a.ID_NUMBER, b.BUTTON_NUMBER " +
                                      "FROM EMP a " +
                                      "LEFT OUTER JOIN BUTTON b ON a.EMP_NO = b.BUTTON_HLDR " +
                                      "WHERE a.EMP_NO = @EMPNO";
                Command.Parameters.Add("@EMPNO", FbDbType.VarChar).Value = employeeNumber;
                var reader = Command.ExecuteReader();

                Employee employee = null;
                while (reader.Read())
                {
                    employee = new Employee
                    {
                        EmployeeeNo = reader["EMP_NO"].ToString(),
                        CardNumber = reader["BUTTON_NUMBER"].ToString(),
                        DepartmentNo = reader["DEPARTMENT"].ToString(),
                        Suspended = reader["DISCHARGED"].ToString() == "Y",
                        IdNumber = reader["ID_NUMBER"].ToString()
                    };
                }
                return employee;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                Connection.Close();
            }
        }

        public IEnumerable<Employee> GetTmpEmployees()
        {
            try
            {
                Command = new FbCommand();
                Command.Connection = Connection;
                Connection.Open();

                var transaction = Connection.BeginTransaction();
                Command.Transaction = transaction;

                Command.CommandText = "SELECT a.EMP_NO, a.DEPARTMENT, a.DISCHARGED, a.ID_NUMBER, b.BUTTON_NUMBER " +
                                      "FROM EMP a " +
                                      "LEFT OUTER JOIN BUTTON b ON a.EMP_NO = b.BUTTON_HLDR";
                var reader = Command.ExecuteReader();

                var employees = new List<Employee>();
                while (reader.Read())
                {
                    var employee = new Employee
                    {
                        EmployeeeNo = reader["EMP_NO"].ToString(),
                        CardNumber = reader["BUTTON_NUMBER"].ToString(),
                        DepartmentNo = reader["DEPARTMENT"].ToString(),
                        Suspended = reader["DISCHARGED"].ToString() == "Y",
                        IdNumber = reader["ID_NUMBER"].ToString()
                    };

                    employees.Add(employee);
                }
                return employees;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                Connection.Close();
            }
        }

        public IEnumerable<Company> GetTmpCompanies()
        {
            try
            {
                Command = new FbCommand();
                Command.Connection = Connection;
                Connection.Open();

                var transaction = Connection.BeginTransaction();
                Command.Transaction = transaction;

                Command.CommandText = "SELECT a.CODE FROM COMPANIES a ";
                var reader = Command.ExecuteReader();

                var companies = new List<Company>();
                while (reader.Read())
                {
                    var company = new Company
                    {
                        Code = reader["CODE"].ToString()
                    };
                    companies.Add(company);
                }
                return companies;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                Connection.Close();
            }
        }

        public IEnumerable<Roster> GetTmpRosters()
        {
            try
            {
                Command = new FbCommand();
                Command.Connection = Connection;
                Connection.Open();

                var transaction = Connection.BeginTransaction();
                Command.Transaction = transaction;

                Command.CommandText = "SELECT a.CODE, a.DESCRIPTION FROM ROSTERS a ";
                var reader = Command.ExecuteReader();

                var rosters = new List<Roster>();
                while (reader.Read())
                {
                    var roster = new Roster
                    {
                        Code = reader["CODE"].ToString(),
                        Name = reader["DESCRIPTION"].ToString()
                    };
                    rosters.Add(roster);
                }
                return rosters;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                Connection.Close();
            }
        }

        public void GetTmpRosterDates(ref Roster roster)
        {
            try
            {
                Command = new FbCommand();
                Command.Connection = Connection;
                Connection.Open();

                var transaction = Connection.BeginTransaction();
                Command.Transaction = transaction;

                Command.CommandText =
                    $"SELECT a.CODE, a.ROSTERDATE, a.SHIFTS, a.DEDUCTHOURS, a.DEDUCTNT, a.DEDUCTOT1, a.DEDUCTOT2, a.DEDUCTOT3, a.DEDUCTOT4, a.TARGETNT, a.TARGETOT1, a.TARGETOT2, a.TARGETOT3, a.TARGETOT4, a.BALANCINGDIRECTION, a.MAXOT0, a.MAXOT1, a.MAXOT2, a.MAXOT3, a.MAXOT4 FROM ROSTERDATES a WHERE a.CODE = '{roster.Code}'";
                var reader = Command.ExecuteReader();

                roster.RosterDates = new List<RosterDate>();
                while (reader.Read())
                {
                    var rosterDate = new RosterDate
                    {
                        Code = reader["CODE"].ToString(),
                        StartDate = Convert.ToDateTime(reader["ROSTERDATE"].ToString()),
                        Shifts = reader["SHIFTS"].ToString(),
                        DeductHours = reader["DEDUCTHOURS"].ToString()[0],
                        DeductNt = reader["DEDUCTNT"].ToString()[0],
                        DeductOt1 = reader["DEDUCTOT1"].ToString()[0],
                        DeductOt2 = reader["DEDUCTOT2"].ToString()[0],
                        DeductOt3 = reader["DEDUCTOT3"].ToString()[0],
                        DeductOt4 = reader["DEDUCTOT4"].ToString()[0],
                        TargetNt = (int)reader["TARGETNT"],
                        TargetOt1 = (int)reader["TARGETOT1"],
                        TargetOt2 = (int)reader["TARGETOT2"],
                        TargetOt3 = (int)reader["TARGETOT3"],
                        TargetOt4 = (int)reader["TARGETOT4"],
                        BalancingDirection = reader["BALANCINGDIRECTION"].ToString()[0],
                        MaxOt0 = (int)reader["MAXOT0"],
                        MaxOt1 = (int)reader["MAXOT1"],
                        MaxOt2 = (int)reader["MAXOT2"],
                        MaxOt3 = (int)reader["MAXOT3"],
                        MaxOt4 = (int)reader["MAXOT4"]
                    };
                    roster.RosterDates.Add(rosterDate);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
        }

        public void CreateTmpDepartment(Department department)
        {
            try
            {
                Command = new FbCommand();
                Command.Connection = Connection;
                Connection.Open();

                var transaction = Connection.BeginTransaction();
                Command.Transaction = transaction;

                Command.CommandText = "INSERT INTO DEPARTMENTS (CODE, DESCRIPTION) VALUES (@CODE, @DESCRIPTION)";
                Command.Parameters.Add("@CODE", FbDbType.VarChar).Value = department.Id;
                Command.Parameters.Add("@DESCRIPTION", FbDbType.VarChar).Value = department.Name.Length >
                                                                                              20
                    ? department.Name.Substring(0, 20)
                    : department.Name;
                Command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                Connection.Close();
            }
        }

        public void CreateTmpCompany(Company company)
        {
            try
            {
                Command = new FbCommand();
                Command.Connection = Connection;
                Connection.Open();

                var transaction = Connection.BeginTransaction();
                Command.Transaction = transaction;

                Command.CommandText = "INSERT INTO COMPANIES (CODE, DESCRIPTION) VALUES (@CODE, @DESCRIPTION)";
                Command.Parameters.Add("@CODE", FbDbType.VarChar).Value = company.Code;
                Command.Parameters.Add("@DESCRIPTION", FbDbType.VarChar).Value = company.Description;
                Command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                Connection.Close();
            }
        }

        public void CreateTmpEmployee(Employee employee)
        {
            try
            {
                Command = new FbCommand();
                Command.Connection = Connection;
                Connection.Open();

                var transaction = Connection.BeginTransaction();
                Command.Transaction = transaction;

                Command.CommandText = "INSERT INTO EMP " +
                                      "(EMP_NO, ID_NUMBER, NAME, SURNAME, OCCUPATION, COST_CENTRE, GRADE, WORKPATTERN, " +
                                      "DISCHARGED, EMPLOYMENT_DATE, DISCHARGE_DATE, HOME_ADD, POST_ADD, TEL_NO, NOK, " +
                                      "EMERGENCY_CONTACT, POSITION_APPLIED_FOR, BIRTHDATE, MARITAL_STATUS, SEX, LANGUAGES, " +
                                      "NATIONALITY, SA_RESIDENT, PREV_EMPLOYED, PREV_APPLICATIONS, BLACKLISTED, HOURLYRATE, " +
                                      "EARNINGS_BONUS, EARNINGS_ALLOWANCE, EARNINGS_IOD, EARNINGS_OTHER1, EARNINGS_OTHER2, " +
                                      "EARNINGS_OTHER3, EARNINGS_OTHER4, DEDUCT_UIF, DEDUCT_TAX, DEDUCT_IC, DEDUCT_UNION, " +
                                      "DEDUCT_LOAN, DEDUCT_OTHER1, DEDUCT_OTHER2, DEDUCT_OTHER3, DEDUCT_OTHER4, ABSENTFROM, " +
                                      "ABSENTTO, HOLIDAYCALENDAR, ISACTIVE, DEPARTMENT, COMPANY, INVOICERATENT, INVOICERATEOT1, " +
                                      "INVOICERATEOT2, INVOICERATEOT3, INVOICERATEOT4, ROSTER, ROSTERED, HRINFO, " +
                                      "SCHEDULEDWORKPATTERNS, REPORTFILTER) " +
                                      "" +
                                      "VALUES " +
                                      "(@EMPNO, @IDNUMBER, @NAME, @SURNAME, '01', '01', '01', '7-17', " +
                                      "'N', @EMPLOYMENTDATE, @DISCHARGEDATE, '','','',''," +
                                      "'','', @BIRTHDATE,'','','', " +
                                      "'','','','','', 0.000000, " +
                                      "0.000000, 0.000000, 0.000000, 0.000000, 0.000000, " +
                                      "0.000000, 0.000000, 0.000000, 0.000000, 0.000000, 0.000000, " +
                                      "0.000000, 0.000000, 0.000000, 0.000000, 0.000000, @ABSENTFROM, " +
                                      "@ABSENTTO, '01', '', @DEPARTMENT, @COMPANY, 0.000000, 0.000000, " +
                                      "0.000000, 0.000000, 0.000000, '', 'F', '-1,-1,-1,-1,-1,-1,', " +
                                      "'F', 'Y')";
                Command.Parameters.Add("@EMPNO", FbDbType.VarChar).Value =
                    employee.EmployeeeNo.Length > 10
                        ? employee.EmployeeeNo.Substring(0, 10)
                        : employee.EmployeeeNo;
                Command.Parameters.Add("@IDNUMBER", FbDbType.VarChar).Value = employee.IdNumber.Length >
                                                                                           13
                    ? employee.IdNumber.Substring(0, 13)
                    : employee.IdNumber;
                Command.Parameters.Add("@NAME", FbDbType.VarChar).Value = employee.Name.Length > 30
                    ? employee.Name.Substring(0, 30).ToUpper()
                    : employee.Name.ToUpper();
                Command.Parameters.Add("@SURNAME", FbDbType.VarChar).Value = employee.LastName.Length > 30
                    ? employee.LastName.Substring(0, 30).ToUpper()
                    : employee.LastName.ToUpper();
                Command.Parameters.Add("@EMPLOYMENTDATE", FbDbType.TimeStamp).Value = DateTime.Now;
                Command.Parameters.Add("@DISCHARGEDATE", FbDbType.TimeStamp).Value = DateTime.Now;
                Command.Parameters.Add("@BIRTHDATE", FbDbType.TimeStamp).Value = DateTime.Now;
                Command.Parameters.Add("@ABSENTFROM", FbDbType.TimeStamp).Value = DateTime.MinValue;
                Command.Parameters.Add("@ABSENTTO", FbDbType.TimeStamp).Value = DateTime.MinValue;
                Command.Parameters.Add("@DEPARTMENT", FbDbType.VarChar).Value = employee.DepartmentNo;
                Command.Parameters.Add("@COMPANY", FbDbType.VarChar).Value = employee.Employer == ""
                    ? "1"
                    : employee.Employer;
                Command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
        }

        public void CreateTmpCardNumber(Employee employee)
        {
            try
            {
                Command = new FbCommand();
                Command.Connection = Connection;
                Connection.Open();

                var transaction = Connection.BeginTransaction();
                Command.Transaction = transaction;

                Command.CommandText = "INSERT INTO BUTTON " +
                                      "(BUTTON_NUMBER, BUTTON_HLDR, EXPIRY_DATE) " +
                                      "" +
                                      "VALUES " +
                                      "(@BUTTONNO, @BUTTONHLDR, @EXPIRY)";
                Command.Parameters.Add("@BUTTONNO", FbDbType.VarChar).Value = employee.CardNumber.Length >
                                                                                           10
                    ? employee.CardNumber.Substring(0, 10)
                    : employee.CardNumber;
                Command.Parameters.Add("@BUTTONHLDR", FbDbType.VarChar).Value =
                    employee.EmployeeeNo.Length > 10
                        ? employee.EmployeeeNo.Substring(0, 10)
                        : employee.EmployeeeNo;
                Command.Parameters.Add("@EXPIRY", FbDbType.Date).Value = DateTime.MaxValue;

                Command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
        }

        public void CreateTmpRosterDate(RosterDate rosterDate)
        {
            try
            {
                Command = new FbCommand();
                Command.Connection = Connection;
                Connection.Open();

                var transaction = Connection.BeginTransaction();
                Command.Transaction = transaction;

                Command.CommandText = "INSERT INTO ROSTERDATES " +
                                      "(CODE, ROSTERDATE, SHIFTS, DEDUCTHOURS, DEDUCTNT, DEDUCTOT1, DEDUCTOT2, DEDUCTOT3, DEDUCTOT4, TARGETNT, TARGETOT1, TARGETOT2, TARGETOT3, TARGETOT4, BALANCINGDIRECTION, MAXOT0, MAXOT1, MAXOT2, MAXOT3, MAXOT4) " +
                                      "" +
                                      "VALUES " +
                                      "(@CODE, @ROSTERDATE, @SHIFTS, @DEDUCTHOURS, @DEDUCTNT, @DEDUCTOT1, @DEDUCTOT2, @DEDUCTOT3, @DEDUCTOT4, @TARGETNT, @TARGETOT1, @TARGETOT2, @TARGETOT3, @TARGETOT4, @BALANCINGDIRECTION, @MAXOT0, @MAXOT1, @MAXOT2, @MAXOT3, @MAXOT4)";

                Command.Parameters.Add("@CODE", FbDbType.VarChar).Value = rosterDate.Code;
                Command.Parameters.Add("@ROSTERDATE", FbDbType.Date).Value = rosterDate.StartDate;
                Command.Parameters.Add("@SHIFTS", FbDbType.VarChar).Value = rosterDate.Shifts;
                Command.Parameters.Add("@DEDUCTHOURS", FbDbType.Char).Value = rosterDate.DeductHours;
                Command.Parameters.Add("@DEDUCTNT", FbDbType.Char).Value = rosterDate.DeductNt;
                Command.Parameters.Add("@DEDUCTOT1", FbDbType.Char).Value = rosterDate.DeductOt1;
                Command.Parameters.Add("@DEDUCTOT2", FbDbType.Char).Value = rosterDate.DeductOt2;
                Command.Parameters.Add("@DEDUCTOT3", FbDbType.Char).Value = rosterDate.DeductOt3;
                Command.Parameters.Add("@DEDUCTOT4", FbDbType.Char).Value = rosterDate.DeductOt4;
                Command.Parameters.Add("@TARGETNT", FbDbType.Integer).Value = rosterDate.TargetNt;
                Command.Parameters.Add("@TARGETOT1", FbDbType.Integer).Value = rosterDate.TargetOt1;
                Command.Parameters.Add("@TARGETOT2", FbDbType.Integer).Value = rosterDate.TargetOt2;
                Command.Parameters.Add("@TARGETOT3", FbDbType.Integer).Value = rosterDate.TargetOt3;
                Command.Parameters.Add("@TARGETOT4", FbDbType.Integer).Value = rosterDate.TargetOt4;
                Command.Parameters.Add("@BALANCINGDIRECTION", FbDbType.Char).Value =
                    rosterDate.BalancingDirection;
                Command.Parameters.Add("@MAXOT0", FbDbType.Integer).Value = rosterDate.MaxOt0;
                Command.Parameters.Add("@MAXOT1", FbDbType.Integer).Value = rosterDate.MaxOt1;
                Command.Parameters.Add("@MAXOT2", FbDbType.Integer).Value = rosterDate.MaxOt2;
                Command.Parameters.Add("@MAXOT3", FbDbType.Integer).Value = rosterDate.MaxOt3;
                Command.Parameters.Add("@MAXOT4", FbDbType.Integer).Value = rosterDate.MaxOt4;

                Command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                Connection.Close();
            }
        }

        public void EditTmpAttachments(string tmpEmployeeNumber,
            string updatedEmployeeNumber)
        {
            try
            {
                Command = new FbCommand();
                Command.Connection = Connection;
                Connection.Open();

                var transaction = Connection.BeginTransaction();
                Command.Transaction = transaction;
                Command.CommandText = "UPDATE ATTACHMENTS " +
                                      "SET EMP_NO = @NEW_EMPNO " +
                                      "WHERE EMP_NO = @OLD_EMPNO";

                Command.Parameters.Add("@NEW_EMPNO", FbDbType.VarChar).Value =
                    updatedEmployeeNumber.Length > 10
                        ? updatedEmployeeNumber.Substring(0, 10)
                        : updatedEmployeeNumber;

                Command.Parameters.Add("@OLD_EMPNO", FbDbType.VarChar).Value =
                    tmpEmployeeNumber.Length > 10
                        ? tmpEmployeeNumber.Substring(0, 10)
                        : tmpEmployeeNumber;

                Command.ExecuteNonQuery();
                transaction.Commit();
            }
            finally
            {
                Connection.Close();
            }
        }

        public void EditTmpButton(string tmpEmployeeNumber,
            string updatedEmployeeNumber)
        {
            try
            {
                Command = new FbCommand();
                Command.Connection = Connection;
                Connection.Open();

                var transaction = Connection.BeginTransaction();
                Command.Transaction = transaction;
                Command.CommandText = "UPDATE BUTTON " +
                                      "SET BUTTON_HLDR = @NEW_EMPNO " +
                                      "WHERE BUTTON_HLDR = @OLD_EMPNO";

                Command.Parameters.Add("@NEW_EMPNO", FbDbType.VarChar).Value =
                    updatedEmployeeNumber.Length > 10
                        ? updatedEmployeeNumber.Substring(0, 10)
                        : updatedEmployeeNumber;

                Command.Parameters.Add("@OLD_EMPNO", FbDbType.VarChar).Value =
                    tmpEmployeeNumber.Length > 10
                        ? tmpEmployeeNumber.Substring(0, 10)
                        : tmpEmployeeNumber;

                Command.ExecuteNonQuery();
                transaction.Commit();
            }
            finally
            {
                Connection.Close();
            }
        }

        public void EditTmpClockD(string tmpEmployeeNumber,
            string updatedEmployeeNumber)
        {
            try
            {
                Command = new FbCommand();
                Command.Connection = Connection;
                Connection.Open();

                var transaction = Connection.BeginTransaction();
                Command.Transaction = transaction;
                Command.CommandText = "UPDATE CLOCKD " +
                                      "SET EMPNO = @NEW_EMPNO " +
                                      "WHERE EMPNO = @OLD_EMPNO";

                Command.Parameters.Add("@NEW_EMPNO", FbDbType.VarChar).Value =
                    updatedEmployeeNumber.Length > 10
                        ? updatedEmployeeNumber.Substring(0, 10)
                        : updatedEmployeeNumber;

                Command.Parameters.Add("@OLD_EMPNO", FbDbType.VarChar).Value =
                    tmpEmployeeNumber.Length > 10
                        ? tmpEmployeeNumber.Substring(0, 10)
                        : tmpEmployeeNumber;

                Command.ExecuteNonQuery();
                transaction.Commit();
            }
            finally
            {
                Connection.Close();
            }
        }

        public void EditTmpClocking(string tmpEmployeeNumber,
            string updatedEmployeeNumber)
        {
            try
            {
                Command = new FbCommand();
                Command.Connection = Connection;
                Connection.Open();

                var transaction = Connection.BeginTransaction();
                Command.Transaction = transaction;
                Command.CommandText = "UPDATE CLOCKING " +
                                      "SET CODE = @NEW_EMPNO " +
                                      "WHERE CODE = @OLD_EMPNO";

                Command.Parameters.Add("@NEW_EMPNO", FbDbType.VarChar).Value =
                    updatedEmployeeNumber.Length > 10
                        ? updatedEmployeeNumber.Substring(0, 10)
                        : updatedEmployeeNumber;

                Command.Parameters.Add("@OLD_EMPNO", FbDbType.VarChar).Value =
                    tmpEmployeeNumber.Length > 10
                        ? tmpEmployeeNumber.Substring(0, 10)
                        : tmpEmployeeNumber;

                Command.ExecuteNonQuery();
                transaction.Commit();
            }
            finally
            {
                Connection.Close();
            }
        }

        public void EditTmpEmp_EmpNo(string tmpEmployeeNumber,
            string updatedEmployeeNumber)
        {
            try
            {
                Command = new FbCommand();
                Command.Connection = Connection;
                Connection.Open();

                var transaction = Connection.BeginTransaction();
                Command.Transaction = transaction;
                Command.CommandText = "UPDATE EMP " +
                                      "SET EMP_NO = @NEW_EMPNO " +
                                      "WHERE EMP_NO = @OLD_EMPNO";

                Command.Parameters.Add("@NEW_EMPNO", FbDbType.VarChar).Value =
                    updatedEmployeeNumber.Length > 10
                        ? updatedEmployeeNumber.Substring(0, 10)
                        : updatedEmployeeNumber;

                Command.Parameters.Add("@OLD_EMPNO", FbDbType.VarChar).Value = tmpEmployeeNumber.Length >
                                                                                            10
                    ? tmpEmployeeNumber.Substring(0, 10)
                    : tmpEmployeeNumber;

                Command.ExecuteNonQuery();
                transaction.Commit();
            }
            finally
            {
                Connection.Close();
            }
        }

        public void EditTmpEmployeeDisciplinary(string tmpEmployeeNumber, string updatedEmployeeNumber)
        {
            try
            {
                Command = new FbCommand();
                Command.Connection = Connection;
                Connection.Open();

                var transaction = Connection.BeginTransaction();
                Command.Transaction = transaction;
                Command.CommandText = "UPDATE EMPLOYEEDISCIPLINARY " +
                                      "SET EMP_NO = @NEW_EMPNO " +
                                      "WHERE EMP_NO = @OLD_EMPNO";

                Command.Parameters.Add("@NEW_EMPNO", FbDbType.VarChar).Value =
                    updatedEmployeeNumber.Length > 10
                        ? updatedEmployeeNumber.Substring(0, 10)
                        : updatedEmployeeNumber;

                Command.Parameters.Add("@OLD_EMPNO", FbDbType.VarChar).Value =
                    tmpEmployeeNumber.Length > 10
                        ? tmpEmployeeNumber.Substring(0, 10)
                        : tmpEmployeeNumber;

                Command.ExecuteNonQuery();
                transaction.Commit();
            }
            finally
            {
                Connection.Close();
            }
        }

        public void EditTmpEmployeeLeaveInfo(
            string tmpEmployeeNumber, string updatedEmployeeNumber)
        {
            try
            {
                Command = new FbCommand();
                Command.Connection = Connection;
                Connection.Open();

                var transaction = Connection.BeginTransaction();
                Command.Transaction = transaction;
                Command.CommandText = "UPDATE EMPLOYEELEAVEINFO " +
                                      "SET EMP_NO = @NEW_EMPNO " +
                                      "WHERE EMP_NO = @OLD_EMPNO";

                Command.Parameters.Add("@NEW_EMPNO", FbDbType.VarChar).Value =
                    updatedEmployeeNumber.Length > 10
                        ? updatedEmployeeNumber.Substring(0, 10)
                        : updatedEmployeeNumber;

                Command.Parameters.Add("@OLD_EMPNO", FbDbType.VarChar).Value =
                    tmpEmployeeNumber.Length > 10
                        ? tmpEmployeeNumber.Substring(0, 10)
                        : tmpEmployeeNumber;

                Command.ExecuteNonQuery();
                transaction.Commit();
            }
            finally
            {
                Connection.Close();
            }
        }

        public void EditTmpEmployeeLicenses(string tmpEmployeeNumber, string updatedEmployeeNumber)
        {
            try
            {
                Command = new FbCommand();
                Command.Connection = Connection;
                Connection.Open();

                var transaction = Connection.BeginTransaction();
                Command.Transaction = transaction;
                Command.CommandText = "UPDATE EMPLOYEELICENSES " +
                                      "SET EMP_NO = @NEW_EMPNO " +
                                      "WHERE EMP_NO = @OLD_EMPNO";

                Command.Parameters.Add("@NEW_EMPNO", FbDbType.VarChar).Value =
                    updatedEmployeeNumber.Length > 10
                        ? updatedEmployeeNumber.Substring(0, 10)
                        : updatedEmployeeNumber;

                Command.Parameters.Add("@OLD_EMPNO", FbDbType.VarChar).Value =
                    tmpEmployeeNumber.Length > 10
                        ? tmpEmployeeNumber.Substring(0, 10)
                        : tmpEmployeeNumber;

                Command.ExecuteNonQuery();
                transaction.Commit();
            }
            finally
            {
                Connection.Close();
            }
        }

        public void EditTmpEmployeeLimitations(
            string tmpEmployeeNumber, string updatedEmployeeNumber)
        {
            try
            {
                Command = new FbCommand();
                Command.Connection = Connection;
                Connection.Open();

                var transaction = Connection.BeginTransaction();
                Command.Transaction = transaction;
                Command.CommandText = "UPDATE EMPLOYEELIMITATIONS " +
                                      "SET EMP_NO = @NEW_EMPNO " +
                                      "WHERE EMP_NO = @OLD_EMPNO";

                Command.Parameters.Add("@NEW_EMPNO", FbDbType.VarChar).Value =
                    updatedEmployeeNumber.Length > 10
                        ? updatedEmployeeNumber.Substring(0, 10)
                        : updatedEmployeeNumber;

                Command.Parameters.Add("@OLD_EMPNO", FbDbType.VarChar).Value =
                    tmpEmployeeNumber.Length > 10
                        ? tmpEmployeeNumber.Substring(0, 10)
                        : tmpEmployeeNumber;

                Command.ExecuteNonQuery();
                transaction.Commit();
            }
            finally
            {
                Connection.Close();
            }
        }

        public void EditTmpFlexiTime(string tmpEmployeeNumber,
            string updatedEmployeeNumber)
        {
            try
            {
                Command = new FbCommand();
                Command.Connection = Connection;
                Connection.Open();

                var transaction = Connection.BeginTransaction();
                Command.Transaction = transaction;
                Command.CommandText = "UPDATE FLEXITIME " +
                                      "SET EMP_NO = @NEW_EMPNO " +
                                      "WHERE EMP_NO = @OLD_EMPNO";

                Command.Parameters.Add("@NEW_EMPNO", FbDbType.VarChar).Value =
                    updatedEmployeeNumber.Length > 10
                        ? updatedEmployeeNumber.Substring(0, 10)
                        : updatedEmployeeNumber;

                Command.Parameters.Add("@OLD_EMPNO", FbDbType.VarChar).Value =
                    tmpEmployeeNumber.Length > 10
                        ? tmpEmployeeNumber.Substring(0, 10)
                        : tmpEmployeeNumber;

                Command.ExecuteNonQuery();
                transaction.Commit();
            }
            finally
            {
                Connection.Close();
            }
        }

        public void EditTmpHoursSummary(string tmpEmployeeNumber,
            string updatedEmployeeNumber)
        {
            try
            {
                Command = new FbCommand();
                Command.Connection = Connection;
                Connection.Open();

                var transaction = Connection.BeginTransaction();
                Command.Transaction = transaction;
                Command.CommandText = "UPDATE HOURSSUMMARY " +
                                      "SET EMP_NO = @NEW_EMPNO " +
                                      "WHERE EMP_NO = @OLD_EMPNO";

                Command.Parameters.Add("@NEW_EMPNO", FbDbType.VarChar).Value =
                    updatedEmployeeNumber.Length > 10
                        ? updatedEmployeeNumber.Substring(0, 10)
                        : updatedEmployeeNumber;

                Command.Parameters.Add("@OLD_EMPNO", FbDbType.VarChar).Value =
                    tmpEmployeeNumber.Length > 10
                        ? tmpEmployeeNumber.Substring(0, 10)
                        : tmpEmployeeNumber;

                Command.ExecuteNonQuery();
                transaction.Commit();
            }
            finally
            {
                Connection.Close();
            }
        }

        public void EditTmpLeaveRecords(string tmpEmployeeNumber,
            string updatedEmployeeNumber)
        {
            try
            {
                Command = new FbCommand();
                Command.Connection = Connection;
                Connection.Open();

                var transaction = Connection.BeginTransaction();
                Command.Transaction = transaction;
                Command.CommandText = "UPDATE LEAVERECORDS " +
                                      "SET EMP_NO = @NEW_EMPNO " +
                                      "WHERE EMP_NO = @OLD_EMPNO";

                Command.Parameters.Add("@NEW_EMPNO", FbDbType.VarChar).Value =
                    updatedEmployeeNumber.Length > 10
                        ? updatedEmployeeNumber.Substring(0, 10)
                        : updatedEmployeeNumber;

                Command.Parameters.Add("@OLD_EMPNO", FbDbType.VarChar).Value =
                    tmpEmployeeNumber.Length > 10
                        ? tmpEmployeeNumber.Substring(0, 10)
                        : tmpEmployeeNumber;

                Command.ExecuteNonQuery();
                transaction.Commit();
            }
            finally
            {
                Connection.Close();
            }
        }

        public void EditTmpOldLeaveRecords(
            string tmpEmployeeNumber, string updatedEmployeeNumber)
        {
            try
            {
                Command = new FbCommand();
                Command.Connection = Connection;
                Connection.Open();

                var transaction = Connection.BeginTransaction();
                Command.Transaction = transaction;
                Command.CommandText = "UPDATE OLDLEAVERECORDS " +
                                      "SET EMP_NO = @NEW_EMPNO " +
                                      "WHERE EMP_NO = @OLD_EMPNO";

                Command.Parameters.Add("@NEW_EMPNO", FbDbType.VarChar).Value =
                    updatedEmployeeNumber.Length > 10
                        ? updatedEmployeeNumber.Substring(0, 10)
                        : updatedEmployeeNumber;

                Command.Parameters.Add("@OLD_EMPNO", FbDbType.VarChar).Value =
                    tmpEmployeeNumber.Length > 10
                        ? tmpEmployeeNumber.Substring(0, 10)
                        : tmpEmployeeNumber;

                Command.ExecuteNonQuery();
                transaction.Commit();
            }
            finally
            {
                Connection.Close();
            }
        }

        public void EditTmpPhotos(string tmpEmployeeNumber,
            string updatedEmployeeNumber)
        {
            try
            {
                Command = new FbCommand();
                Command.Connection = Connection;
                Connection.Open();

                var transaction = Connection.BeginTransaction();
                Command.Transaction = transaction;
                Command.CommandText = "UPDATE PHOTOS " +
                                      "SET EMPNO = @NEW_EMPNO " +
                                      "WHERE EMPNO = @OLD_EMPNO";

                Command.Parameters.Add("@NEW_EMPNO", FbDbType.VarChar).Value =
                    updatedEmployeeNumber.Length > 10
                        ? updatedEmployeeNumber.Substring(0, 10)
                        : updatedEmployeeNumber;

                Command.Parameters.Add("@OLD_EMPNO", FbDbType.VarChar).Value =
                    tmpEmployeeNumber.Length > 10
                        ? tmpEmployeeNumber.Substring(0, 10)
                        : tmpEmployeeNumber;

                Command.ExecuteNonQuery();
                transaction.Commit();
            }
            finally
            {
                Connection.Close();
            }
        }

        public void EditTmpTrainingRecords(
            string tmpEmployeeNumber, string updatedEmployeeNumber)
        {
            try
            {
                Command = new FbCommand();
                Command.Connection = Connection;
                Connection.Open();

                var transaction = Connection.BeginTransaction();
                Command.Transaction = transaction;
                Command.CommandText = "UPDATE TRAININGRECORDS " +
                                      "SET EMP_NO = @NEW_EMPNO " +
                                      "WHERE EMP_NO = @OLD_EMPNO";

                Command.Parameters.Add("@NEW_EMPNO", FbDbType.VarChar).Value =
                    updatedEmployeeNumber.Length > 10
                        ? updatedEmployeeNumber.Substring(0, 10)
                        : updatedEmployeeNumber;

                Command.Parameters.Add("@OLD_EMPNO", FbDbType.VarChar).Value =
                    tmpEmployeeNumber.Length > 10
                        ? tmpEmployeeNumber.Substring(0, 10)
                        : tmpEmployeeNumber;

                Command.ExecuteNonQuery();
                transaction.Commit();
            }
            finally
            {
                Connection.Close();
            }
        }

        public void EditTmpWorkPatternSchedules(
            string tmpEmployeeNumber, string updatedEmployeeNumber)
        {
            try
            {
                Command = new FbCommand();
                Command.Connection = Connection;
                Connection.Open();

                var transaction = Connection.BeginTransaction();
                Command.Transaction = transaction;
                Command.CommandText = "UPDATE WORKPATTERNSCHEDULES " +
                                      "SET EMP_NO = @NEW_EMPNO " +
                                      "WHERE EMP_NO = @OLD_EMPNO";

                Command.Parameters.Add("@NEW_EMPNO", FbDbType.VarChar).Value =
                    updatedEmployeeNumber.Length > 10
                        ? updatedEmployeeNumber.Substring(0, 10)
                        : updatedEmployeeNumber;

                Command.Parameters.Add("@OLD_EMPNO", FbDbType.VarChar).Value =
                    tmpEmployeeNumber.Length > 10
                        ? tmpEmployeeNumber.Substring(0, 10)
                        : tmpEmployeeNumber;

                Command.ExecuteNonQuery();
                transaction.Commit();
            }
            finally
            {
                Connection.Close();
            }
        }
    }
}
