using Microsoft.AspNetCore.Mvc;
using HRMS.API.Repositories;

namespace HRMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PayrollController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("payslips/{month}/{year}")]
        public IActionResult GetAllPayslips(int month, int year)
        {
            return Ok(_unitOfWork.Payroll.GetAllPayslips(month, year));
        }

        [HttpGet("employee-payslips/{employeeId}")]
        public IActionResult GetPayslipsByEmployee(int employeeId)
        {
            return Ok(_unitOfWork.Payroll.GetPayslipsByEmployee(employeeId));
        }

        [HttpPost("upsert-salary")]
        public IActionResult UpsertEmployeeSalary([FromBody] EmployeeSalaryDto req)
        {
            _unitOfWork.Payroll.UpsertEmployeeSalary(req);
            return Ok(new { Message = "Salary component updated" });
        }
    }

    public class EmployeeSalaryDto
    {
        public int EmployeeId { get; set; }
        public int ComponentId { get; set; }
        public decimal Amount { get; set; }
    }
}
