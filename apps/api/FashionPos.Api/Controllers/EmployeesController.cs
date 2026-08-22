using FashionPos.Api.Data;
using FashionPos.Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FashionPos.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly FashionPosDbContext _db;

        public EmployeesController(FashionPosDbContext db)
        {
            _db = db;
        }

        // GET: api/v1/employees
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _db.Employees
                .OrderByDescending(e => e.Id)
                .Select(e => new
                {
                    e.Id,
                    e.FullName,
                    e.Username,
                    Role = e.Role.ToString(),
                    Status = e.Status.ToString()
                })
                .ToListAsync();

            return Ok(new
            {
                success = true,
                statusCode = 200,
                total = employees.Count,
                data = employees
            });
        }

        // POST: api/v1/employees
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false,
                    statusCode = 400,
                    message = "Dữ liệu nhân viên không hợp lệ!"
                });
            }

            // Check duplicate username
            var existingUsername = await _db.Employees
                .AnyAsync(e => e.Username.ToLower() == dto.Username.ToLower());

            if (existingUsername)
            {
                return Conflict(new
                {
                    success = false,
                    statusCode = 409,
                    message = $"Tên đăng nhập '{dto.Username}' đã tồn tại!"
                });
            }

            // Hash password with BCrypt
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            Enum.TryParse<EmployeeRoleEnum>(dto.Role, true, out var roleEnum);

            var employee = new Employee
            {
                FullName = dto.FullName,
                Username = dto.Username,
                PasswordHash = passwordHash,
                Role = roleEnum,
                Status = EmployeeStatusEnum.ACTIVE
            };

            _db.Employees.Add(employee);
            await _db.SaveChangesAsync();

            return Created(string.Empty, new
            {
                success = true,
                statusCode = 201,
                message = "Thêm nhân viên mới thành công!",
                data = new
                {
                    employeeId = employee.Id,
                    fullName = employee.FullName,
                    username = employee.Username,
                    role = employee.Role.ToString(),
                    status = employee.Status.ToString()
                }
            });
        }
    }
}
