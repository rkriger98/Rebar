using Microsoft.AspNetCore.Mvc;
using Rebar.Models;
using Rebar.Services;
using System.Text.Json.Serialization;

namespace Rebar.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShakeController : Controller
    {
        private readonly IShakeService _shakeService;
        public ShakeController(IShakeService shakeService)
        {
            _shakeService = shakeService;
        }

        // GET: api/Shake
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var shakes = await _shakeService.GetAllAsyc();
            return Ok(shakes);
        }

        // GET api/ShakeController/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var shake = await _shakeService.GetById(id);
            if (shake == null)
            {
                return NotFound();
            }
            return Ok(shake);
        }

        // POST api/ShakeController
        [HttpPost]
        public async Task<IActionResult> Post(Shake shake)
        {
            await _shakeService.CreateAsync(shake);
            return Ok("created successfully");
        }
    }
}

