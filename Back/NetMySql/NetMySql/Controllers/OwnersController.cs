using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetMySql.Data.Repositories;
using NetMySql.Model;

namespace NetMySql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnersController(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        [HttpGet]
        public  async Task<IActionResult> GetAllOwners()
        {
            return Ok(await _ownerRepository.GetAllOwners());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOwnerById(int id)
        {
            return Ok(await _ownerRepository.GetOwnerById(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateOwner([FromBody] Owner owner)
        {
            if (owner == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var created = await _ownerRepository.InsertOwner(owner);
            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOwner([FromBody] Owner owner)
        {
            if (owner == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _ownerRepository.UpdateOwner(owner);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOwner(int id)
        {
            await _ownerRepository.DeleteOwner(new Owner { IdOwner = id});
            return NoContent();
        }
    }
}
