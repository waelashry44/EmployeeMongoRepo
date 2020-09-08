using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EmployeeMongoDB.Models;
using EmployeeMongoDB.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMongoDB.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeesController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
       
        [HttpGet("GetEmployeeById")]
        public IActionResult Get(int id)
        {

            var employee = _employeeService.Get(id);
            if (employee != null)
                return Ok(new {employee, HttpStatusCode.OK });
            return BadRequest(HttpStatusCode.NotFound);
        }
        [HttpGet("EmployeesList")]
        public IActionResult GetAll()
        {
            var employees = _employeeService.GetAll();
            if (employees.Any())
                return Ok(new { employees, HttpStatusCode.OK });
            return BadRequest(HttpStatusCode.NotFound);
        }
        [HttpPost("CreateEmployee")]
        public void Post([FromBody] Employee employee)
        {
            _employeeService.Insert(employee);

        }
        [HttpGet("DeleteEmployee")]
        public void Delete(int id)
        {
            _employeeService.Delete(id);
        }
        [HttpPost("UpdateEmployee")]
        public void Put([FromBody] Employee employee)
        {
            _employeeService.Update(employee);
        }


    }
}
