using Microsoft.AspNetCore.Mvc;
using HRMS.API.Repositories;
using System;

namespace HRMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AttendanceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("daily/{date}")]
        public IActionResult GetDailyAttendance(DateTime date)
        {
            return Ok(_unitOfWork.Attendance.GetDailyAttendance(date));
        }

        [HttpPost("upsert")]
        public IActionResult UpsertAttendance([FromBody] AttendanceDto att)
        {
            _unitOfWork.Attendance.UpsertAttendance(att);
            return Ok(new { Message = "Attendance saved successfully" });
        }
    }

    public class AttendanceDto
    {
        public int EmployeeId { get; set; }
        public DateTime LogDate { get; set; }
        public TimeSpan? CheckIn { get; set; }
        public TimeSpan? CheckOut { get; set; }
        public string Status { get; set; } = "Present";
    }
}
