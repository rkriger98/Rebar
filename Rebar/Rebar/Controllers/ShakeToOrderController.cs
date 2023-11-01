using Microsoft.AspNetCore.Mvc;
using Rebar.Models;
using Rebar.Services;

namespace Rebar.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShakeToOrderController : Controller
    {
        private readonly IShakeToOrderService _shakeToOrderService;
        public ShakeToOrderController(IShakeToOrderService shakeToOrderService)
        {
            _shakeToOrderService = shakeToOrderService;
        }

        // GET: api/_shakeToOrderService
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var shakes = await _shakeToOrderService.GetAllAsyc();
            return Ok(shakes);
        }

        // GET api/_shakeToOrderService/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var shake = await _shakeToOrderService.GetById(id);
            if (shake == null)
            {
                return NotFound();
            }
            return Ok(shake);
        }

        // POST api/ShakeToOrderController
        [HttpPost]
        public async Task<IActionResult> Post(ShakeToOrder shakeToOrder)
        {
            await _shakeToOrderService.CreateAsync(shakeToOrder);
            return Ok("created successfully");
        }
    }
}
