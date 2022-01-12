using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IEmployeeBusinessLayer
    {
        IEnumerable<EmployeeMaster> GetAllEmployee();

        IEnumerable<EmployeeMaster> GetEmployeeByID(long empId);
        
        //EmployeeMaster AddEmployee(EmployeeMaster employee);
        bool AddEmployee(EmployeeMaster employee);

        //EmployeeMaster UpdateEmployee(EmployeeMaster employee);
        bool UpdateEmployee(EmployeeMaster employee);

        //long DeleteEmployee(long empId);
        bool DeleteEmployee(long empId);
    }
}
