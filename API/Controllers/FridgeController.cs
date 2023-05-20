using API.Models;
using API.Repository;
using API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FridgeController : ControllerBase
    {
        public readonly IFridgeRepository _repository;
        public FridgeController(IFridgeRepository repository) => _repository = repository;

        // GET: api/<FridgeController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fridge>>> GetAsync()
        {
            var fridge = await _repository.GetAll();
            return Ok(fridge);
        }
        // GET api/<FridgeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Fridge>>> Get(Guid id)
        {
            var FindFridge = await _repository.GetFridgeToId(id);
            return Ok(FindFridge);
        }

        // POST api/<FridgeController>
        [HttpPost]
        public async Task <ActionResult<Fridge>> AddFridge(Fridge fridge)
        {
            await _repository.Create(fridge);
            if(fridge != null)
            {
                return CreatedAtAction("GetProduct", new { id = fridge.Id }, fridge);
            }
            return NoContent();
        }

        //// PUT api/<FridgeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] Fridge fridge)
        {
            var Updater = await _repository.UpdateFridge(fridge);
            if (!Updater)
            {
                return BadRequest();
            }
            return Ok(Updater);
        }

        // DELETE api/<FridgeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var DeleteFridge = await _repository.DeleteFridge(new Fridge());
            if (!DeleteFridge)
                return NotFound();
            else
                return NoContent();
        }
    }
}
