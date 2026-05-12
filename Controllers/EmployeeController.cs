using Microsoft.AspNetCore.Mvc;
using HRMS.API.Repositories;
using System;

namespace HRMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(_unitOfWork.Employees.GetEmployees());
        }

        [HttpPost]
        public IActionResult UpsertEmployee([FromBody] UpsertEmployeeDto emp)
        {
            _unitOfWork.Employees.UpsertEmployee(emp);
            return Ok(new { Message = "Employee saved successfully" });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            _unitOfWork.Employees.DeleteEmployee(id);
            return Ok(new { Message = "Employee deleted successfully" });
        }

        [HttpPut("archive/{id}")]
        public IActionResult ArchiveEmployee(int id)
        {
            _unitOfWork.Employees.ArchiveEmployee(id);
            return Ok(new { Message = "Employee archived successfully" });
        }
    }

    public class UpsertEmployeeDto
    {
        public int Id { get; set; } = 0;
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int DeptId { get; set; }
        public int DesigId { get; set; }
        public DateTime DateOfJoining { get; set; }
        public bool IsActive { get; set; }
    }
}
