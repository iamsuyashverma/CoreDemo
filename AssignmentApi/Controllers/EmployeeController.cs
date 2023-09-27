using AssignmentApi.Models;
using AssignmentApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssignmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employeeService) { this.employeeService = employeeService; }

        // GET: api/<EmployeeController>
        [HttpGet]
        public ResponseModel Get()
        {
            return new ResponseModel(200, employeeService.GetEmployees());
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{employeeId}")]
        public ResponseModel Get(long employeeId)
        {
            var employee = employeeService.GetEmployee(employeeId);
            return new ResponseModel(200, employee);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public long Post([FromBody] TblEmployee employee)
        {
            return employeeService.AddEmployee(employee);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{employeeId}")]
        public void Delete(long employeeId)
        {
            employeeService.DeleteEmployee(employeeId);
        }
    }
}
