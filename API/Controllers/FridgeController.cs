using API.DTO;
using API.Models;
using API.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FridgeController : ControllerBase
    {
        private readonly IFridgeRepository _repository;
        private readonly IMapper _mapper;

        public FridgeController(IFridgeRepository repository, IMapper mapper)
            => (_repository, _mapper) = (repository, mapper);

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FridgeDTO>>> GetAsync()
            => Ok(_mapper.Map<List<FridgeDTO>>(await _repository.GetAll()));
        
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<FridgeDTO>>> Get([FromRoute]string id)
            => Ok(_mapper.Map<FridgeDTO>(await _repository.GetFridgeToId(Guid.Parse(id))));

        [HttpPost]
        public async Task<ActionResult> AddFridge([FromBody] CreateFridgeDTO fridgeDTO)
        {
            var fridge = _mapper.Map<Fridge>(fridgeDTO);
            var createdFridge = await _repository.Create(fridge);
            if (createdFridge != null)
            {
                return Ok();
            }

            return BadRequest("Cant save fridge");
        }

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

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var isDeleted = await _repository.DeleteFridge(new Fridge());
            if (!isDeleted)
                return NotFound();
            else
                return NoContent();
        }
    }
}
