using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using User_Management_API.Data;
using User_Management_API.Dtos.Employee;
using User_Management_API.Dtos.Users;
using User_Management_API.Models;

namespace User_Management_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly HRDbContext _context;

        public EmployeeController(HRDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees.Include(e => e.Department).ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context
                .Employees.Include(e => e.Department)
                .FirstOrDefaultAsync(e => e.EmployeeID == id);

            if (employee == null)
                return NotFound();

            var employeeDto = new EmployeeReadDto
            {
                EmployeeID = employee.EmployeeID,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                DepartmentName = employee.Department.Name,
            };

            return Ok(employeeDto);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(EmployeeCreateDto employeeDto)
        {
            var employee = new Employee
            {
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                DepartmentID = employeeDto.DepartmentID,
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmployeeID }, employee);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(
            int id,
            EmployeeCreateDto employeeDto
        )
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound("Employee does not exist in database");
            }

            employee.FirstName = employeeDto.FirstName;
            employee.LastName = employeeDto.LastName;
            employee.DepartmentID = employeeDto.DepartmentID;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!await EmployeeExists(id))
                {
                    return NotFound("Employee was deleted by another user during the update.");
                }
                return Conflict(
                    "The record was modified by another user. Please reload and try again."
                );
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("FK_") == true)
                {
                    return BadRequest("Invalid DepartmentID provided.");
                }

                return StatusCode(500, "An error occurred while updating the database.");
            }

            return Ok(employee);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            try
            {
                var affectedRows = await _context
                    .Employees.Where(e => e.EmployeeID == id)
                    .ExecuteDeleteAsync();

                return affectedRows == 0
                    ? NotFound($"Nie znaleziono pracownika o ID {id}.")
                    : NoContent();
            }
            catch (DbUpdateException)
            {
                return BadRequest(
                    "Nie można usunąć pracownika, ponieważ posiada przypisane zadania lub inne powiązania."
                );
            }
        }

        private async Task<bool> EmployeeExists(int id)
        {
            return await _context.Employees.AnyAsync(e => e.EmployeeID == id);
        }
    }
}
