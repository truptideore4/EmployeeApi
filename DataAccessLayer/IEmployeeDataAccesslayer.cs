using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IEmployeeDataAccesslayer
    {
        IEnumerable<EmployeeMaster> GetAllEmployee();
        IEnumerable<EmployeeMaster> GetEmployeeByID(long empId);
        EmployeeMaster AddEmployee(EmployeeMaster employee);
        EmployeeMaster UpdateEmployee(EmployeeMaster employee);
        long DeleteEmployee(long empId);
    }
}
