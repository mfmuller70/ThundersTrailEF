using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThundersTrailEF.Data;
using ThundersTrailEF.Models;

namespace ThundersTrailEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly DataContext _context;

        public EmployeesController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// lista Employees
        /// </summary>
        /// <remarks>
        /// Sample request: GET/
        /// </remarks>
        /// <returns>Uma lista recuperada</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="400">Erro 400</response>
        /// <response code="401">Usuário não autorizado</response>
        /// <response code="422">Não foi possível processar requisição</response>
        /// <response code="500">Erro de API</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
          if (_context.Employees == null)
          {
              return NotFound();
          }
            return await _context.Employees.ToListAsync();
        }

        /// <summary>
        /// lista Employees
        /// </summary>
        /// <remarks>
        /// Sample request: GET/
        /// </remarks>
        /// <returns>Uma lista recuperada</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="400">Erro 400</response>
        /// <response code="401">Usuário não autorizado</response>
        /// <response code="422">Não foi possível processar requisição</response>
        /// <response code="500">Erro de API</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
          if (_context.Employees == null)
          {
              return NotFound();
          }
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        /// <summary>
        /// lista Employees
        /// </summary>
        /// <remarks>
        /// Sample request: GET/
        /// </remarks>
        /// <returns>Uma lista recuperada</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="400">Erro 400</response>
        /// <response code="401">Usuário não autorizado</response>
        /// <response code="422">Não foi possível processar requisição</response>
        /// <response code="500">Erro de API</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
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
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Updated the information successfully !");
        }

        /// <summary>
        /// lista Employees
        /// </summary>
        /// <remarks>
        /// Sample request: GET/
        /// </remarks>
        /// <returns>Uma lista recuperada</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="400">Erro 400</response>
        /// <response code="401">Usuário não autorizado</response>
        /// <response code="422">Não foi possível processar requisição</response>
        /// <response code="500">Erro de API</response>
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
          if (_context.Employees == null)
          {
              return Problem("Entity set 'DataContext.Employees'  is null.");
          }
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
        }

        /// <summary>
        /// lista Employees
        /// </summary>
        /// <remarks>
        /// Sample request: GET/
        /// </remarks>
        /// <returns>Uma lista recuperada</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="400">Erro 400</response>
        /// <response code="401">Usuário não autorizado</response>
        /// <response code="422">Não foi possível processar requisição</response>
        /// <response code="500">Erro de API</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            if (_context.Employees == null)
            {
                return NotFound();
            }
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return Ok("Deleted the information successfully !");
        }

        private bool EmployeeExists(int id)
        {
            return (_context.Employees?.Any(e => e.EmployeeId == id)).GetValueOrDefault();
        }
    }
}
