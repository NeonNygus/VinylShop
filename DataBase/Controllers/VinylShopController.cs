using VinylShop.EfCore;
using VinylShop.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VinylShop.Controllers
{
    [ApiController]
    public class VinylShopController : ControllerBase
    {
        private readonly DbHelper _db;
        public VinylShopController(EF_DataContext eF_DataContext)
        {
            _db = new DbHelper(eF_DataContext);
        }
        // GET: api/<VinylShopController>
        [HttpGet]
        [Route("api/[controller]/GetVinyls")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                
                IEnumerable<VinylModel> data = _db.GetVinyls();
                if(!data.Any()) 
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppRepsonse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // GET api/<VinylShopController>/5
        [HttpGet]
        [Route("api/[controller]/GetVinylById/{id}")]

        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {

                VinylModel data = _db.GetVinylsById(id);
                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppRepsonse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // POST api/<VinylShopController>
        [HttpPost]
        [Route("api/[controller]/SaveVinyl")]

        public IActionResult Post([FromBody] VinylModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveVinyl(model);
                return Ok(ResponseHandler.GetAppRepsonse(type, model));
            }
            catch (Exception ex) {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));

            }
        }

        // PUT api/<VinylShopController>/5
        [HttpPut]
        [Route("api/[controller]/UpdateVinyl")]
        public IActionResult Put([FromBody] VinylModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveVinyl(model);
                return Ok(ResponseHandler.GetAppRepsonse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));

            }
        }

        // DELETE api/<VinylShopController>/5
        [HttpDelete]
        [Route("api/[controller]/DeleteVinyl/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteVinyl(id);
                return Ok(ResponseHandler.GetAppRepsonse(type, "Delete Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));

            }
        }
    }
}
