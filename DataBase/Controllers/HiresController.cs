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
    public class HiresController : Controller
    {
        private readonly DbHelper _db;
        public HiresController(EF_DataContext eF_DataContext)
        {
            _db = new DbHelper(eF_DataContext);
        }

     
        [HttpGet]
        [Route("api/[controller]/GetHires")]
        public IActionResult Index()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<HireModel> data = _db.GetHires();
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
        [Route("api/[controller]/SaveHire")]
        public IActionResult Post([Bind("HireId,VinylId,CustId,HireDate,ReturnDate,IsClosed")] HireModel hire)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveHire(hire);
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
        [Route("api/[controller]/GetHireDetails/{id}")]

        public IActionResult Details(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {

                HireModel data = _db.GetHireById(id);
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
        [Route("api/[controller]/EditHire/{id}")]
        public IActionResult Edit(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {

                HireModel data = _db.GetHireById(id);
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
        [Route("api/[controller]/UpdateHire")]
        public IActionResult Put([Bind("HireId,VinylId,CustId,HireDate,ReturnDate,IsClosed")] HireModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveHire(model);
                //return Ok(ResponseHandler.GetAppRepsonse(type, model));
                IEnumerable<HireModel> data = _db.GetHires();
                return View("Index",data);
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));

            }
        }
        
        [HttpGet]
        [Route("api/[controller]/HireToDelete/{id}")]
        public IActionResult HireToDelete(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {

                HireModel data = _db.GetHireById(id);
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
        [Route("api/[controller]/DeleteHire")]
        public IActionResult Delete([Bind("HireId,VinylId,CustId,HireDate,ReturnDate,IsClosed")] HireModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteHire(model.HireId);
                //return Ok(ResponseHandler.GetAppRepsonse(type, "Delete Successfully"));
                IEnumerable<HireModel> data = _db.GetHires();
                return View("Index", data);
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));

            }
        }
    }
}
