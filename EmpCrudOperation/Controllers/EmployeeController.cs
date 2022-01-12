using BusinessLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmpCrudOperation.Controllers
{
    //[RoutePrefix("api/Employee")]
    [LogCustomExceptionFilter]
    public class EmployeeController : ApiController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IEmployeeBusinessLayer _empBusinessLayer;

        public EmployeeController(IEmployeeBusinessLayer empBusinessLayer)
        {
            this._empBusinessLayer = empBusinessLayer;
        }

        [ValidateModel]
        public HttpResponseMessage Get()
        {
            try
            {
                var Data = _empBusinessLayer.GetAllEmployee();
                if (Data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, Data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No Records Found");
                }
            }
            catch (Exception ex)
            {
                log.Error("Exception ", ex);
                //Log logObj = new Log();
                //logObj.insertException("Message : " + ex.Message.ToString());
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [ValidateModel]
        public HttpResponseMessage Get(long id)
        {
            try
            {
                if (id == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Missing Parameters");
                }
                var Data = _empBusinessLayer.GetEmployeeByID(id);
                if (Data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, Data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No Records Found");
                }
            }
            catch (Exception ex)
            {
                log.Error("Test ", ex);
                //Log logObj = new Log();
                //logObj.insertException("Message : " + ex.Message.ToString());
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                //return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [ValidateModel]
        public HttpResponseMessage Post(EmployeeMaster employee)
        {
            try
            {
                var Data = _empBusinessLayer.AddEmployee(employee);
                if(Data == true)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, "Employee Added Successfully");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Missing Parameters");
                }
            }
            catch (Exception ex)
            {
                log.Error("Employee Create", ex);
                ModelState.AddModelError("Error", ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                //return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [ValidateModel]
        public HttpResponseMessage Put(long id , EmployeeMaster employee)
        {
            try
            {
                //if (employee == null)
                //{
                //    return Request.CreateResponse(HttpStatusCode.BadRequest, "Missing Parameters");
                //}
                var Data = _empBusinessLayer.UpdateEmployee(employee);
                if (Data == true)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, "Employee Updated Successfully");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Missing Parameters");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [ValidateModel]
        public HttpResponseMessage Delete(long id)
        {
            try
            {
                //if (id == 0)
                //{
                //    return Request.CreateResponse(HttpStatusCode.BadRequest, "Missing Parameters");
                //}
                var Data = _empBusinessLayer.DeleteEmployee(id);
                if(Data == true)
                {
                   return Request.CreateResponse(HttpStatusCode.Created, "Employee Deleted Successfully");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Missing Parameters");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
