using Microsoft.AspNetCore.Mvc;
using CompanyAPI.Data;
namespace CompanyAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly CompanyDbContext _context;

        public OrdersController(CompanyDbContext context)
        {
            _context = context;
        }

        [HttpGet("orders")]
        public IActionResult GetAllOrdersWithProductNames()
        {
            var orders = _context.Orders
                .Join(_context.Products,
                      order => order.Product_Id,
                      product => product.ID,
                      (order, product) => new
                      {
                          Order_Id = order.ID,
                          Product_Id = product.ID,
                          Product_Name = product.Name
                      })
                .OrderByDescending(o => o.Order_Id) // Descending Order
                .ToList();

            return Ok(orders);
        }
    }
}

