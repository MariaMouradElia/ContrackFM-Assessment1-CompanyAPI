using Microsoft.AspNetCore.Mvc;
using CompanyAPI.Data;
namespace CompanyAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly CompanyDbContext _context;

        public EmployeesController(CompanyDbContext context)
        {
            _context = context;
        }

        [HttpGet("employees")]
        public IActionResult GetAllEmployees()
        {
            var employees = (from e in _context.Employees
                             join d in _context.Departments on e.Department_Id equals d.ID
                             select new
                             {
                                 Employee_Id = e.ID,
                                 Employee_Name = e.Name,
                                 Department_Name = d.Name
                             }).ToList();
            return Ok(employees);
        }
    }
}