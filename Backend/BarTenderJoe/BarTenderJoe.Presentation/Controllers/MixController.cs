using BarTenderJoe.Application.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarTenderJoe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MixController : ControllerBase
    {
        private readonly MixDrinkHandler _handler;
        public MixController(MixDrinkHandler handler) { _handler = handler; }

        [HttpPost]
        public IActionResult Mix([FromBody] MixDrinkCommand cmd)
        {
            var result = _handler.Handle(cmd);
            return result != null
                ? Ok(result)  
                : BadRequest(new { message = "Invalid product for mixing" });
        }
    }
}
