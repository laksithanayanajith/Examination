using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Examination.Data;
using Examination.Models;
using Examination.Services.EmployeeService;
using Examination.DTOs.EmployeeDTO;

namespace Examination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<List<EmployeeDTO>>> GetEmployee()
        {
            return await _employeeService.GetEmployee();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployee(int id)
        {
            var employee = await _employeeService.GetEmployee(id);

            if (employee is null)
            {
                return NotFound(string.Format("{0} employee not found", id));
            }

            return Ok(employee);
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, [FromBody] Employee employee)
        {
            var updateemployee = await _employeeService.PutEmployee(id, employee);

            if (updateemployee is null)
            {
                return NotFound(string.Format("{0} employee not found", id));
            }

            return Ok(updateemployee);
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee([FromBody] CreateEmployeeDTO createEmployeeDTO)
        {

            try
            {
                var newemployee = await _employeeService.PostEmployee(createEmployeeDTO);
                return Ok(newemployee);
            }
            catch (Exception)
            {

                return BadRequest("Cannot add new employee!");
            }
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _employeeService.DeleteEmployee(id);

            if (employee is null)
            {
                return NotFound(string.Format("{0} employee not found", id));
            }

            return Ok(employee);
        }
    }
}
