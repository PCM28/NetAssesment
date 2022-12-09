using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetMySql.Data.Repositories;
using NetMySql.Model;

namespace NetMySql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private readonly IClaimRepository _claimRepository;

        public ClaimsController(IClaimRepository claimRepository)
        {
            _claimRepository = claimRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllClaims()
        {
            return Ok(await _claimRepository.GetAllClaims());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClaimById(int id)
        {
            return Ok(await _claimRepository.GetClaimById(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateClaim([FromBody] Claim claim)
        {
            if (claim == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var created = await _claimRepository.InsertClaim(claim);
            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateClaim([FromBody] Claim claim)
        {
            if (claim == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _claimRepository.UpdateClaim(claim);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            await _claimRepository.DeleteClaim(new Claim { IdClaim= id });
            return NoContent();
        }
    }
}
