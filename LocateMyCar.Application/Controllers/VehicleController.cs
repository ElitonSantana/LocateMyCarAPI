using LocateMyCar.Domain.Entities;
using LocateMyCar.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace LocateMyCar.Application.Controllers
{
    [ApiController]
    [Route("api")]
    public class VehicleController : ControllerBase
    {

        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        #region :: Vehicle ::

        [HttpGet("Vehicle")]
        public IActionResult GetVehicles()
        {
            var result = _vehicleService.GetAll();

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet("Vehicle/{id}")]
        public IActionResult GetVehicle(int id)
        {
            if (id == 0)
                return BadRequest("Id inválido!");

            var result = _vehicleService.GetById(id);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("Vehicle")]
        public IActionResult CreateVehicle(VehicleRequest vehicle)
        {
            var result = _vehicleService.Create(vehicle);
            if (result.Success)
                return Created("", result);
            else
                return BadRequest(result);
        }

        [HttpPut("Vehicle/{id}")]
        public IActionResult UpdateVehicle(int id, VehicleRequest vehicle)
        {
            if (id != vehicle.VehicleId)
                return BadRequest("Id inválido!");

            var result = _vehicleService.Update(vehicle);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpDelete("Vehicle/{id}")]
        public IActionResult DeleteVehicle(int id)
        {
            var result = _vehicleService.Delete(id);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet("Vehicle/GetTopVehicles")]
        public IActionResult GetTopVehicles()
        {
            var result = _vehicleService.GetTopVehiclesOlders();

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        #endregion

        #region :: VehicleDetails ::
        [HttpGet("VehicleDetails/{id}")]
        public IActionResult GetVehicleDetails(int id)
        {
            if (id == 0)
                return BadRequest("Id inválido!");

            var result = _vehicleService.GetVehicleDetailById(id);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("VehicleDetails")]
        public IActionResult CreateVehicleDetails(VehicleDetailRequest vehicleDetail)
        {
            var result = _vehicleService.CreateVehicleDetail(vehicleDetail);
            if (result.Success)
                return Created("", result);
            else
                return BadRequest(result);
        }

        [HttpPut("VehicleDetails/{id}")]
        public IActionResult UpdateVehicleDetails(int id, VehicleDetailRequest vehicleDetail)
        {
            if (id != vehicleDetail.VehicleId)
                return BadRequest("Id inválido!");

            var result = _vehicleService.UpdateVehicleDetail(vehicleDetail);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpDelete("VehicleDetails/{id}")]
        public IActionResult DeleteVehicleDetails(int id)
        {
            var result = _vehicleService.DeleteVehicleDetail(id);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
        #endregion

    }
}
