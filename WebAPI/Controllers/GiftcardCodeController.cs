using BL.Facades.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GiftcardCodeController : ControllerBase
    {
        private readonly IGiftcardFacade _giftcardFacade;

        public GiftcardCodeController(IGiftcardFacade giftcardFacade)
        {
            _giftcardFacade = giftcardFacade;
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var result = await _giftcardFacade.GetCodeByValueAsync(code);

            if (result.IsFailed)
                return NotFound(result.Errors);

            return Ok(result.Value);
        }

        [HttpGet("{code}/validate")]
        public async Task<IActionResult> Validate(string code)
        {
            var result = await _giftcardFacade.ValidateCodeAsync(code);

            if (result.IsFailed)
                return BadRequest(result.Errors);

            return Ok(result.Value);
        }
    }
}
