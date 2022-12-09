using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetMySql.Data.Repositories;
using NetMySql.Model;

namespace NetMySql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehiclesController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllVehicles()
        {
            return Ok(await _vehicleRepository.GetAllVehicles());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleById(int id)
        {
            return Ok(await _vehicleRepository.GetVehicleById(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateOwner([FromBody] Vehicle vehicle)
        {
            if (vehicle == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var created = await _vehicleRepository.InsertVehicle(vehicle);
            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVehicle([FromBody] Vehicle vehicle)
        {
            if (vehicle == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _vehicleRepository.UpdateVehicle(vehicle);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            await _vehicleRepository.DeleteVehicle(new Vehicle{ IdVehicle = id });
            return NoContent();
        }
    }
}
