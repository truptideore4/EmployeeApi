using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer;
using System.Web.ModelBinding;

namespace BusinessLayer
{
    public class EmployeeBusinessLayer : IEmployeeBusinessLayer
    {
        private IEmployeeDataAccesslayer _empDataAccess;

        public EmployeeBusinessLayer(IEmployeeDataAccesslayer empDataAccess)
        {
            _empDataAccess = empDataAccess;
        }

        public IEnumerable<EmployeeMaster> GetAllEmployee()
        {
            return _empDataAccess.GetAllEmployee();
        }

        public IEnumerable<EmployeeMaster> GetEmployeeByID(long empId)
        {
           return _empDataAccess.GetEmployeeByID(empId);
        }

        public bool AddEmployee(EmployeeMaster employee)
        {
            if (!ModelState.Equals(employee, null))
            {
                _empDataAccess.AddEmployee(employee);
                return true;
            }
            else
            {
                return false;
                //return _empDataAccess.AddEmployee(employee);
            }  
        }

        public bool UpdateEmployee(EmployeeMaster employee)
        {
            if (!ModelState.Equals(employee, null))
            {
                _empDataAccess.UpdateEmployee(employee);
                return true;
            }
            else
            {
                return false;
            }
            //return _empDataAccess.UpdateEmployee(employee);
        }

        public bool DeleteEmployee(long empId)
        {
            if (ModelState.Equals(empId, 0))
            {
                return false;
            }
            else
            {
                _empDataAccess.DeleteEmployee(empId);
                return true;
            }
            //return _empDataAccess.DeleteEmployee(empId);
        }
    }
}