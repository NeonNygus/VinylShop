using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data;
using System.Reflection.Emit;
using VinylShop.EfCore;
using VinylShop.Model;

namespace VinylShop.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly DbHelper _db;
        public EmployeesController(EF_DataContext eF_DataContext)
        {
            _db = new DbHelper(eF_DataContext);
        }

     
        [HttpGet]
        [Route("api/[controller]/GetEmployees")]
        public IActionResult Index()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<EmployeeModel> data = _db.GetEmployees();
                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return View(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpPost]
        [Route("api/[controller]/SaveEmployee")]
        public IActionResult Post([Bind("EmpId,FirstName,LastName,Adress,PhoneNum")] EmployeeModel employee)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveEmployee(employee);
                //return Ok(ResponseHandler.GetAppRepsonse(type, vinyl));
                return View("Create");
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));

            }
        }
        public IActionResult Create()
        {
                return View();
        }

        [HttpGet]
        [Route("api/[controller]/GetEmployeeDetails/{id}")]

        public IActionResult Details(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {

                EmployeeModel data = _db.GetEmployeeById(id);
                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                //return Ok(ResponseHandler.GetAppRepsonse(type, data));
                return View(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
        
        [HttpGet]
        [Route("api/[controller]/EditEmployee/{id}")]
        public IActionResult Edit(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {

                EmployeeModel data = _db.GetEmployeeById(id);
                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                //return Ok(ResponseHandler.GetAppRepsonse(type, data));
                return View(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpPost]
        [Route("api/[controller]/UpdateEmployee")]
        public IActionResult Put([Bind("EmpId,FirstName,LastName,Adress,PhoneNum")] EmployeeModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveEmployee(model);
                //return Ok(ResponseHandler.GetAppRepsonse(type, model));
                IEnumerable<EmployeeModel> data = _db.GetEmployees();
                return View("Index",data);
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));

            }
        }
        
        [HttpGet]
        [Route("api/[controller]/EmployeeToDelete/{id}")]
        public IActionResult EmployeeToDelete(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {

                EmployeeModel data = _db.GetEmployeeById(id);
                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                //return Ok(ResponseHandler.GetAppRepsonse(type, data));
                return View("Delete", data);
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpPost, ActionName("Delete")]
        [Route("api/[controller]/DeleteEmployee")]
        public IActionResult Delete([Bind("EmpId,FirstName,LastName,Adress,PhoneNum")] EmployeeModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteEmployee(model.EmpId);
                //return Ok(ResponseHandler.GetAppRepsonse(type, "Delete Successfully"));
                IEnumerable<EmployeeModel> data = _db.GetEmployees();
                return View("Index", data);
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));

            }
        }
    }
}
