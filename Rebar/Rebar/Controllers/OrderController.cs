using Microsoft.AspNetCore.Mvc;
using Rebar.Models;
using Rebar.Services;

namespace Rebar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var orders = await _orderService.GetAllAsyc();
            return Ok(orders);
        }

        // GET api/OrderController/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var order = await _orderService.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        // POST api/OrderController
        [HttpPost]
        public async Task<IActionResult> Post(Order order)
        {
            await _orderService.CreateAsync(order);
            return Ok("created successfully");
        }
    }
}
