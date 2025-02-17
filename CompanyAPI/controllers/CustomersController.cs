using Microsoft.AspNetCore.Mvc;
using CompanyAPI.Data;
namespace CompanyAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CompanyDbContext _context;

        public CustomersController(CompanyDbContext context)
        {
            _context = context;
        }

        [HttpGet("customers")]
        public IActionResult GetAllCustomers()
        {
            var customersQuery = from c in _context.Customers
                                 join o in _context.Orders on c.ID equals o.Customer_Id into orders
                                 from order in orders.DefaultIfEmpty()
                                 join p in _context.Products on order.Product_Id equals p.ID into products
                                 from product in products.DefaultIfEmpty()
                                 select new
                                 {
                                     Customer_Id = c.ID,
                                     Customer_Name = c.Name,
                                     Order_Id = order != null ? order.ID : null,
                                     Amount = order != null ? (int?)order.Amount : null,  
                                     Product_Name = product != null ? product.Name : null,
                                     Total_Cost = order != null && product != null ? (decimal?)(order.Amount * product.Cost) : null
                                 };

            var customers = customersQuery.ToList();
            return Ok(customers);
        }

    }
}