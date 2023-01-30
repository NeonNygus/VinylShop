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
    public class VinylsController : Controller
    {
        private readonly DbHelper _db;
        public VinylsController(EF_DataContext eF_DataContext)
        {
            _db = new DbHelper(eF_DataContext);
        }

     
        [HttpGet]
        [Route("api/[controller]/GetVinyls")]
        public IActionResult Index()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<VinylModel> data = _db.GetVinyls();
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
        [Route("api/[controller]/SaveVinyl")]
        public IActionResult Post([Bind("VinylId,Title,Artist,Format,ReleaseYear,Genre,Label,CatalogueNum")] VinylModel vinyl)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveVinyl(vinyl);
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
        [Route("api/[controller]/GetVinylDetails/{id}")]

        public IActionResult Details(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {

                VinylModel data = _db.GetVinylsById(id);
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
        [Route("api/[controller]/EditVinyl/{id}")]
        public IActionResult Edit(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {

                VinylModel data = _db.GetVinylsById(id);
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
        [Route("api/[controller]/UpdateVinyl")]
        public IActionResult Put([Bind("VinylId,Title,Artist,Format,ReleaseYear,Genre,Label,CatalogueNum")] VinylModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveVinyl(model);
                //return Ok(ResponseHandler.GetAppRepsonse(type, model));
                IEnumerable<VinylModel> data = _db.GetVinyls();
                return View("Index",data);
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));

            }
        }
        
        [HttpGet]
        [Route("api/[controller]/VinylToDelete/{id}")]
        public IActionResult VinylToDelete(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {

                VinylModel data = _db.GetVinylsById(id);
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
        [Route("api/[controller]/DeleteVinyl")]
        public IActionResult Delete([Bind("VinylId,Title,Artist,Format,ReleaseYear,Genre,Label,CatalogueNum")] VinylModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteVinyl(model.VinylId);
                //return Ok(ResponseHandler.GetAppRepsonse(type, "Delete Successfully"));
                IEnumerable<VinylModel> data = _db.GetVinyls();
                return View("Index", data);
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));

            }
        }
    }
}
