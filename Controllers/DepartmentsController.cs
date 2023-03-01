using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Examination.Data;
using Examination.Models;
using Examination.Services.DepartmentService;
using AutoMapper;
using Examination.DTOs.DepartmentDTO;

namespace Examination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public DepartmentsController(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<List<DepartmentDTO>>> GetDepartment()
        {
          return await _departmentService.GetDepartment();
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(string id)
        {
          var department = await _departmentService.GetDepartment(id);

            if (department is null)
            {
                return NotFound(string.Format("{0} department not found", id));
            }

            return Ok(department);
        }

        // PUT: api/Departments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Department>>> PutDepartment(string id, Department department)
        {
            var updatedepartment = await _departmentService.PutDepartment(id, department);

            if (updatedepartment is null)
            {
                return NotFound(string.Format("{0} department not found", id));
            }

            return Ok(updatedepartment);
        }

        // POST: api/Departments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<List<Department>>> PostDepartment([FromBody] CreateDepartmentDTO createDepartmentDTO)
        {
            try
            {
                var newdepartment = await _departmentService.PostDepartment(createDepartmentDTO);
                return Ok(newdepartment);
            }
            catch (Exception)
            {

                return BadRequest("Cannot create new department!");
            }
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Department>>> DeleteDepartment(string id)
        {
            var department = await _departmentService.DeleteDepartment(id);

            if (department is null)
            {
                return NotFound(string.Format("{0} department not found", id));
            }

            return Ok(department);
        }
    }
}
