using Microsoft.AspNetCore.Mvc;
using toDo1and2.Dtos;
using toDo1and2.Middlewares;
using toDo1and2.Models;

namespace toDo1and2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        public static List<Employee> employees = new();

        [HttpGet("all")]
        public List<Employee> GetAll()
        {
            try
            {
                RequestLoggingMiddleware.stopWath.Start();
                return employees;
            }
            finally
            {
                RequestLoggingMiddleware.stopWath.Stop();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            try
            {
                RequestLoggingMiddleware.stopWath.Start();
                var employee = employees.FirstOrDefault(e => e.Id == id);
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);
            }
            finally
            {
                RequestLoggingMiddleware.stopWath.Stop();
            }
        }

        [HttpPost("create")]
        public ActionResult<Employee> Create(Employee employee)
        {
            try
            {
                RequestLoggingMiddleware.stopWath.Start();
                employees.Add(employee);
                return Created($"/api/[controller]/{employee.Id}", employee);
            }
            finally
            {
                RequestLoggingMiddleware.stopWath.Stop();
            }
        } 
    
        [HttpDelete("delete")]
        public ActionResult<Employee> Delete(int id)
        {
            try
            {
                RequestLoggingMiddleware.stopWath.Start();
                var employee = employees.FirstOrDefault(e => e.Id == id);
                if (employee == null)
                {
                    return NotFound();
                }

                employees.Remove(employee);
                return Ok(employee);
            }
            finally
            {
                RequestLoggingMiddleware.stopWath.Stop();
            }
        }

        [HttpPut("update/{id}")]
        public ActionResult<Employee> Update(int id, EmployeeUpdateDto newEmployee)
        {
            try
            {
                RequestLoggingMiddleware.stopWath.Start();
                var employee = employees.FirstOrDefault(e => e.Id == id);
                if (employee == null)
                {
                    return NotFound();
                }
                employee.Position = newEmployee.Position;
                employee.Salary = newEmployee.Salary;
                employee.IsManager = newEmployee.IsManager;

                return Ok(employee);
            }
            finally
            {
                RequestLoggingMiddleware.stopWath.Stop();
            }
        }
    }
}
