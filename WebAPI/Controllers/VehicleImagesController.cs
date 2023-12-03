using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleImagesController : ControllerBase
    {
        IVehicleImagesService _vehicleImageService;
        public VehicleImagesController(IVehicleImagesService vehicleimageservice)
        {
            _vehicleImageService = vehicleimageservice;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _vehicleImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyvehicleid")]
        public IActionResult GetById(int Id)
        {
            var result = _vehicleImageService.GetByVehicleId(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile file, [FromForm] VehicleImage vehicleImage)
        {
            var result = _vehicleImageService.Add(file,vehicleImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(VehicleImage vehicleImage)
        {
            var vehicleDeleteImage = _vehicleImageService.GetByImageId(vehicleImage.Id).Data;
            var result = _vehicleImageService.Delete(vehicleDeleteImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] VehicleImage vehicleImage)
        {
            var result = _vehicleImageService.Update(file,vehicleImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    
}
}
