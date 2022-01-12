using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DataAccessLayer
{
    public class EmployeeDataAccesslayer : IEmployeeDataAccesslayer
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString);

        public IEnumerable<EmployeeMaster> GetAllEmployee()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "GetAllEmployee";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            //return ds;
            var myData = ds.Tables[0].AsEnumerable().Select(r => new EmployeeMaster
            {
                EmpId = r.Field<long>("EmpId"),
                EmpName = r.Field<string>("EmpName"),
                Designation = r.Field<string>("Designation"),
                DOB = r.Field<DateTime>("DOB"),
                DepartmentId = r.Field<int>("DepartmentId"),
                Department = r.Field<string>("Department")
            });
            var EmployeeList = myData;
            return EmployeeList;
        }

        public IEnumerable<EmployeeMaster> GetEmployeeByID(long empId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "GetAllEmployeeById";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("EmpId", empId);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            //return ds;
            var myData = ds.Tables[0].AsEnumerable().Select(r => new EmployeeMaster
            {
                EmpId = r.Field<long>("EmpId"),
                EmpName = r.Field<string>("EmpName"),
                Designation = r.Field<string>("Designation"),
                DOB = r.Field<DateTime>("DOB"),
                DepartmentId = r.Field<int>("DepartmentId"),
                Department = r.Field<string>("Department")
            });
            var EmployeeList = myData.ToList();
            return EmployeeList;
        }

        public EmployeeMaster AddEmployee(EmployeeMaster employee)
        {
            SqlCommand cmd = new SqlCommand("AddEmployee", con);
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@empName", employee.EmpName);
            cmd.Parameters.AddWithValue("@Designation", employee.Designation);
            cmd.Parameters.AddWithValue("@DOB", employee.DOB);
            cmd.Parameters.AddWithValue("@departmentId", employee.DepartmentId);
            con.Open();
            int rowInserted = cmd.ExecuteNonQuery();
            con.Close();
            return employee;
        }

        public EmployeeMaster UpdateEmployee(EmployeeMaster employee)
        {
            SqlCommand cmd = new SqlCommand("UpdateEmployee", con);
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@empId", employee.EmpId);
            cmd.Parameters.AddWithValue("@empName", employee.EmpName);
            cmd.Parameters.AddWithValue("@Designation", employee.Designation);
            cmd.Parameters.AddWithValue("@DOB", employee.DOB);
            cmd.Parameters.AddWithValue("@departmentId", employee.DepartmentId);
            con.Open();
            int rowInserted = cmd.ExecuteNonQuery();
            con.Close();
            return employee;
        }

        public long DeleteEmployee(long empId)
        {
            SqlCommand cmd = new SqlCommand("DeleteEmployee", con);
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpId", empId);
            con.Open();
            int rowDeleted = cmd.ExecuteNonQuery();
            con.Close();
            return empId;

        }
    }
}