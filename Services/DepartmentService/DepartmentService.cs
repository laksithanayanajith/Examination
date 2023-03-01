using AutoMapper;
using Examination.Data;
using Examination.DTOs.DepartmentDTO;
using Examination.DTOs.EmployeeDTO;
using Examination.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Examination.Services.DepartmentService
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ExaminationContext _context;
        private readonly IMapper _mapper;

        public DepartmentService(ExaminationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<Department>?> DeleteDepartment(string id)
        {
            if (_context.Department is null)
            {
                return null;
            }

            var department = await _context.Department.FindAsync(id);
            if (department is null)
            {
                return null;
            }

            _context.Department.Remove(department);
            await _context.SaveChangesAsync();

            return await _context.Department.ToListAsync();

        }

        public async Task<List<DepartmentDTO>> GetDepartment()
        {
            var departments = await _context.Department.ToListAsync();
            return _mapper.Map<List<DepartmentDTO>>(departments);
        }

        public async Task<DepartmentDTO?> GetDepartment(string id)
        {
            var department = await _context.Department.FindAsync(id);
            if (department is null)
            {
                return null;
            }
            return _mapper.Map<DepartmentDTO>(department);
        }

        public async Task<List<Department>> PostDepartment([FromBody] CreateDepartmentDTO createDepartmentDTO)
        {
            var newdepartment = _mapper.Map<Department>(createDepartmentDTO);
            _context.Department.Add(newdepartment);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (DepartmentExists(newdepartment.DepartmentCode))
                {
                    Console.WriteLine(dbUpdateException);
                }
                else
                {
                    throw;
                }
            }

            return await _context.Department.ToListAsync();
        }

        public async Task<List<Department>?> PutDepartment(string id, [FromBody] Department department)
        {
            if (id != department.DepartmentCode)
            {
                return null;
            }

            _context.Entry(department).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            await _context.SaveChangesAsync();
            return await _context.Department.ToListAsync();
        }

        private bool DepartmentExists(string id)
        {
            return (_context.Department?.Any(e => e.DepartmentCode == id)).GetValueOrDefault();
        }
    }
}
