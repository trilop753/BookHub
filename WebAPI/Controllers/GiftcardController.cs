using BL.DTOs.GiftcardDTOs;
using BL.Facades.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiftcardController : ControllerBase
    {
        private readonly IGiftcardFacade _giftcardFacade;

        public GiftcardController(IGiftcardFacade giftcardFacade)
        {
            _giftcardFacade = giftcardFacade;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GiftcardDto>>> GetAll()
        {
            var res = await _giftcardFacade.GetAllAsync();

            if (res.IsFailed)
            {
                return BadRequest(res.Errors.Select(e => e.Message));
            }

            return Ok(res.Value);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GiftcardDto>> GetById(int id)
        {
            var res = await _giftcardFacade.GetByIdAsync(id);

            if (res.IsFailed)
            {
                return NotFound(res.Errors.Select(e => e.Message));
            }

            return Ok(res.Value);
        }

        [HttpPost]
        public async Task<ActionResult<GiftcardDto>> Create([FromBody] GiftcardCreateDto dto)
        {
            var res = await _giftcardFacade.CreateAsync(dto);

            if (res.IsFailed)
            {
                return BadRequest(res.Errors.Select(e => e.Message));
            }

            return CreatedAtAction(nameof(GetById), new { id = res.Value.Id }, res.Value);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] GiftcardUpdateDto dto)
        {
            var res = await _giftcardFacade.UpdateAsync(id, dto);

            if (res.IsFailed)
            {
                return BadRequest(res.Errors.Select(e => e.Message));
            }

            return Ok(res.Value);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var res = await _giftcardFacade.DeleteAsync(id);

            if (res.IsFailed)
            {
                return BadRequest(res.Errors.Select(e => e.Message));
            }

            return NoContent();
        }

        [HttpGet("{id}/codes")]
        public async Task<ActionResult<IEnumerable<GiftcardCodeDto>>> GetCodes(int id)
        {
            var res = await _giftcardFacade.GetByIdAsync(id);

            if (res.IsFailed)
            {
                return NotFound(res.Errors.Select(e => e.Message));
            }

            return Ok(res.Value.Codes);
        }
    }
}
