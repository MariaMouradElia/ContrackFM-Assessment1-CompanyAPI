using Microsoft.AspNetCore.Mvc;
using CompanyAPI.Data;
namespace CompanyAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private readonly CompanyDbContext _context;

        public SalaryController(CompanyDbContext context)
        {
            _context = context;
        }

        [HttpGet("salary-sum")]
        public IActionResult GetSalarySumByDepartment()
        {
            var salarySum = from d in _context.Departments
                            join e in _context.Employees on d.ID equals e.Department_Id into deptEmployees
                            from employee in deptEmployees.DefaultIfEmpty() // so that departments without employees are also included
                            group employee by new { d.ID, d.Name } into g
                            select new
                            {
                                Department_Id = g.Key.ID,
                                Department_Name = g.Key.Name,
                                Sum_Salary = g.Sum(e => e != null ? e.Salary : 0) // sum of salaries shows zero if there are no employees
                            };

            return Ok(salarySum.ToList());
        }
    }
}