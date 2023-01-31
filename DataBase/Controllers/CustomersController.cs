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
    public class CustomersController : Controller
    {
        private readonly DbHelper _db;
        public CustomersController(EF_DataContext eF_DataContext)
        {
            _db = new DbHelper(eF_DataContext);
        }

     
        [HttpGet]
        [Route("api/[controller]/GetCustomers")]
        public IActionResult Index()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<CustomerModel> data = _db.GetCustomers();
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
        [Route("api/[controller]/SaveCustomer")]
        public IActionResult Post([Bind("CustId,FirstName,LastName,Adress,PhoneNum")] CustomerModel customer)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveCustomer(customer);
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
        [Route("api/[controller]/GetCustomerDetails/{id}")]

        public IActionResult Details(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {

                CustomerModel data = _db.GetCustomerById(id);
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
        [Route("api/[controller]/EditCustomer/{id}")]
        public IActionResult Edit(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {

                CustomerModel data = _db.GetCustomerById(id);
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
        [Route("api/[controller]/UpdateCustomer")]
        public IActionResult Put([Bind("CustId,FirstName,LastName,Adress,PhoneNum")] CustomerModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveCustomer(model);
                //return Ok(ResponseHandler.GetAppRepsonse(type, model));
                IEnumerable<CustomerModel> data = _db.GetCustomers();
                return View("Index",data);
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));

            }
        }
        
        [HttpGet]
        [Route("api/[controller]/CustomerToDelete/{id}")]
        public IActionResult CustomerToDelete(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {

                CustomerModel data = _db.GetCustomerById(id);
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
        [Route("api/[controller]/DeleteCustomer")]
        public IActionResult Delete([Bind("CustId,FirstName,LastName,Adress,PhoneNum")] CustomerModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteCustomer(model.CustId);
                //return Ok(ResponseHandler.GetAppRepsonse(type, "Delete Successfully"));
                IEnumerable<CustomerModel> data = _db.GetCustomers();
                return View("Index", data);
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));

            }
        }
    }
}
