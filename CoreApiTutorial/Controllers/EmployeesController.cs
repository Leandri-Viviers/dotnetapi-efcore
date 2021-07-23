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

    /// <summary>
    /// Get all employees
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(200)]
    [Route("api/[controller]")]
    public IActionResult GetEmployees()
    {
      return Ok(employeeData.GetEmployees());
    }

    /// <summary>
    /// Get an employee by Id
    /// </summary>
    /// <param name="id"> Employee Guid to fetch </param>
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [Route("api/[controller]/{id}")]
    public IActionResult GetEmployee(Guid id)
    {
      var employee = employeeData.GetEmployee(id);

      if (employee != null)
      {
        return Ok(employee);
      }
      return NotFound($"Employee with Id: {id} was not found.");
    }

    /// <summary>
    /// Add a new employee
    /// </summary>
    [HttpPost]
    [Route("api/[controller]")]
    [ProducesResponseType(201)]
    public IActionResult AddEmployee(Employee employee)
    {
      employeeData.AddEmployee(employee);
      return Created($"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}/{employee.Id}", employee);
    }

    /// <summary>
    /// Delete an employee
    /// </summary>
    /// <param name="id"> Employee Guid to remove </param>
    [HttpDelete]
    [Route("api/[controller]/{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public IActionResult DeleteEmployee(Guid id)
    {
      var employee = employeeData.GetEmployee(id);

      if (employee != null)
      {
        employeeData.DeleteEmployee(employee);
        return Ok();
      }
      return NotFound($"Employee with Id: {id} was not found.");
    }

    /// <summary>
    /// Update an employee
    /// </summary>
    /// <param name="id"> Employee Guid to update </param>
    /// <param name="employee"></param>
    [HttpPatch]
    [Route("api/[controller]/{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
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
