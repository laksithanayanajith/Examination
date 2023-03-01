using AutoMapper;
using Examination.Data;
using Examination.DTOs.EmployeeDTO;
using Examination.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Examination.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ExaminationContext _context;
        private readonly IMapper _mapper;

        public EmployeeService(ExaminationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<Employee>?> DeleteEmployee(int id)
        {
            if (_context.Employee is null)
            {
                return null;
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee is null)
            {
                return null;
            }

            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();

            return await _context.Employee.ToListAsync();
        }

        public async Task<List<EmployeeDTO>> GetEmployee()
        {
            var employees = await _context.Employee.ToListAsync();
            return _mapper.Map<List<EmployeeDTO>>(employees);
        }

        public async Task<EmployeeDTO?> GetEmployee(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            if (employee is null)
            {
                return null;
            }
            return _mapper.Map<EmployeeDTO>(employee);
        }

        public async Task<List<Employee>> PostEmployee([FromBody] CreateEmployeeDTO createEmployeeDTO)
        {
            var newemployee = _mapper.Map<Employee>(createEmployeeDTO);
            _context.Employee.Add(newemployee);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (EmployeeExists(newemployee.EmpNo))
                {
                    Console.WriteLine(dbUpdateException);
                }
                else
                {
                    throw;
                }
            }

            return await _context.Employee.ToListAsync();
        }

        public async Task<List<Employee>?> PutEmployee(int id, [FromBody] Employee employee)
        {
            if (id != employee.EmpNo)
            {
                return null;
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            await _context.SaveChangesAsync();
            return await _context.Employee.ToListAsync();
        }

        private bool EmployeeExists(int id)
        {
            return (_context.Employee?.Any(e => e.EmpNo == id)).GetValueOrDefault();
        }
    }
}
