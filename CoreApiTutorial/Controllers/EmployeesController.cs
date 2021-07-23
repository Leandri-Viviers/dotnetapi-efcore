using CoreApiTutorial.EmployeeData;
using CoreApiTutorial.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiTutorial.Controllers
{
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeData employeeData;
        public EmployeesController(IEmployeeData _employeeData)
        {
            employeeData = _employeeData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetEmployees()
        {
            return Ok(employeeData.GetEmployees());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmployee(Guid id)
        {
            var employee = employeeData.GetEmployee(id);

            if(employee != null)
            {
                return Ok(employee);
            }
            return NotFound($"Employee with Id: {id} was not found.");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddEmployee(Employee employee)
        {
            employeeData.AddEmployee(employee);
            return Created($"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}/{employee.Id}", employee);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = employeeData.GetEmployee(id);

            if(employee != null)
            {
                employeeData.DeleteEmployee(employee);
                return Ok();
            }
            return NotFound($"Employee with Id: {id} was not found.");
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult UpdateEmployee(Guid id, Employee employee)
        {
            var result = employeeData.GetEmployee(id);

            if (result != null)
            {
                employee.Id = result.Id;
                employeeData.UpdateEmployee(employee);
                return Ok(employee);
            }
            return NotFound($"Employee with Id: {id} was not found.");
        }
    }
}
