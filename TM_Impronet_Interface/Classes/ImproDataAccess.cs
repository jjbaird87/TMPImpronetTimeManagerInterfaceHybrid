using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using FirebirdSql.Data.FirebirdClient;
using TM_Impronet_Interface.Properties;

namespace TM_Impronet_Interface.Classes
{
    public class ImproDataAccess
    {
        private IDbConnection Connection { get; set; }
        private IDbCommand Command { get; set; }

        public ImproDataAccess()
        {
            Connection = GetConnectionObject();
            Command = GetCommandObject();
        }

        private DbConnection GetConnectionObject()
        {
            if (Settings.Default.UseSql)
                return new SqlConnection(Settings.Default.SQLConnectionString);
            var connectionString =
                "User=SYSDBA;" +
                "Password=masterkey;" +
                "Database=" + Settings.Default.FirebirdDatabasePath + ";" +
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

        private DbCommand GetCommandObject()
        {
            if (Settings.Default.UseSql)
                return new SqlCommand();
            return new FbCommand();
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

        public void UpdateProcessed()
        {
            try
            {
                Command = GetCommandObject();
                Connection.Open();

                var myTransaction = Connection.BeginTransaction();
                Command.Connection = Connection;
                Command.Transaction = myTransaction;
                Command.CommandText = "UPDATE TRANSACK SET TR_PROCESSED = 1 WHERE TR_PROCESSED = 0";
                Command.ExecuteNonQuery();
                myTransaction.Commit();
            }
            finally
            {
                Connection.Close();
            }
        }

        public int GetTransactionCount(DateTime startDate, DateTime endDate)
        {
            try
            {
                Command = GetCommandObject();
                Command.Connection = Connection;

                Connection.Open();
                var transaction = Connection.BeginTransaction();
                Command.Transaction = transaction;

                Command.CommandText =
                    "SELECT COUNT(*) FROM TRANSACK " +
                    "WHERE TR_PROCESSED = 0 AND TR_MSTSQ <> 0";


                var fbCommand = Command as FbCommand;
                if (fbCommand != null)
                {
                    fbCommand.Parameters.Add("@START_DATE", FbDbType.Integer).Value = startDate.ToString("yyyMMdd");
                    fbCommand.Parameters.Add("@END_DATE", FbDbType.Integer).Value = endDate.ToString("yyyMMdd");
                }
                else if (Command is SqlCommand)
                {
                    ((SqlCommand) Command).Parameters.Add("@START_DATE", SqlDbType.Int).Value =
                        startDate.ToString("yyyMMdd");
                    ((SqlCommand) Command).Parameters.Add("@END_DATE", SqlDbType.Int).Value =
                        endDate.ToString("yyyMMdd");
                }

                return Convert.ToInt32(Command.ExecuteScalar());
            }
            finally
            {
                Connection.Close();
            }
        }

        public IDataReader GetUnprocessedTransactions()
        {
            Command = GetCommandObject();
            Command.Connection = Connection;
            Connection.Open();

            Command.CommandText =
                "SELECT * FROM TRANSACK a JOIN EMPLOYEE b ON a.TR_MSTSQ = b.MST_SQ  " +
                "WHERE TR_PROCESSED = 0";

            Command.CommandTimeout = 0;
            return Command.ExecuteReader();
        }

        public IEnumerable<Terminal> GetImproTerminals()
        {
            try
            {
                Command = GetCommandObject();
                Command.Connection = Connection;
                Connection.Open();

                var transaction = Connection.BeginTransaction();
                Command.Transaction = transaction;

                Command.CommandText = "SELECT TERM_SLA, TERM_NAME FROM TERMINAL";

                var reader = Command.ExecuteReader();

                var terminals = new List<Terminal>();
                while (reader.Read())
                {

                    var terminal = new Terminal
                    {
                        Id = reader["TERM_SLA"].ToString(),
                        Name = reader["TERM_NAME"].ToString()
                    };
                    terminals.Add(terminal);
                }
                return terminals;
            }
            finally
            {
                Connection.Close();
            }
        }

        public IEnumerable<Company> GetImproCompanies()
        {
            try
            {
                Command = GetCommandObject();
                Command.Connection = Connection;

                Connection.Open();

                var transaction = Connection.BeginTransaction();
                Command.Transaction = transaction;

                Command.CommandText = "SELECT DISTINCT EMP_Employer FROM EMPLOYEE WHERE EMP_Employer <> \'\'";
                var reader = Command.ExecuteReader();

                var companies = new List<Company>();
                while (reader.Read())
                {
                    var company = new Company
                    {
                        Code = reader["EMP_Employer"].ToString()
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

        public IEnumerable<Employee> GetImproEmployees(string departments)
        {
            try
            {
                Command = GetCommandObject();
                Command.Connection = Connection;
                Connection.Open();

                var transaction = Connection.BeginTransaction();
                Command.Transaction = transaction;

                Command.CommandText =
                    "SELECT DISTINCT EMPLOYEE.MST_SQ, MASTER.MST_FirstName, MASTER.MST_LastName, EMPLOYEE.EMP_Employer, EMPLOYEE.DEPT_No, EMPLOYEE.EMP_EmployeeNo, MASTER.MST_ID " +
                    "FROM EMPLOYEE INNER JOIN MASTER ON EMPLOYEE.MST_SQ = MASTER.MST_SQ  " +
                    "WHERE EMPLOYEE.DEPT_No IN (" + departments + ") AND MST_Current = '1' ";
                var reader = Command.ExecuteReader();

                var employees = new List<Employee>();
                while (reader.Read())
                {
                    var employee = new Employee
                    {
                        CardNumber = reader["MST_SQ"].ToString(),
                        Name = reader["MST_FirstName"].ToString(),
                        LastName = reader["MST_LastName"].ToString(),
                        Employer = reader["EMP_Employer"].ToString(),
                        DepartmentNo = reader["DEPT_No"].ToString(),
                        EmployeeeNo = reader["EMP_EmployeeNo"].ToString(),
                        IdNumber = reader["MST_ID"].ToString() //,
                        //Suspended = reader["TAG_Suspend"].ToString() != "0"
                    };
                    if (employee.EmployeeeNo.Length > 10)
                        employee.EmployeeeNo = employee.EmployeeeNo.Substring(0, 10);
                    employees.Add(employee);
                }
                return employees;
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
                Command = GetCommandObject();
                Command.Connection = Connection;
                Connection.Open();

                var transaction = Connection.BeginTransaction();
                Command.Transaction = transaction;

                Command.CommandText = "SELECT * FROM DEPARTMENT";
                var reader = Command.ExecuteReader();

                var departments = new List<Department>();
                while (reader.Read())
                {
                    var department = new Department
                    {
                        Id = reader["DEPT_No"].ToString(),
                        Name = reader["DEPT_Name"].ToString(),
                        SiteSla = reader["SITE_SLA"].ToString()
                    };
                    departments.Add(department);
                }
                return departments;
            }
            finally
            {
                Connection.Close();
            }
        }

        public List<Department> GetDepartments(string departmentList)
        {
            try
            {
                Command = GetCommandObject();
                Command.Connection = Connection;

                Connection.Open();

                var transaction = Connection.BeginTransaction();
                Command.Transaction = transaction;

                Command.CommandText = $"SELECT * FROM DEPARTMENT WHERE DEPT_No IN ({departmentList})";
                var reader = Command.ExecuteReader();

                var departments = new List<Department>();
                while (reader.Read())
                {
                    var department = new Department
                    {
                        Id = reader["DEPT_No"].ToString(),
                        Name = reader["DEPT_Name"].ToString(),
                        SiteSla = reader["SITE_SLA"].ToString()
                    };
                    departments.Add(department);
                }
                return departments;
            }
            finally
            {
                Connection.Close();
            }
        }

        public void CloseConnection()
        {
            Connection.Close();
        }
    }
}
