using Microsoft.AspNetCore.Mvc;
using HRMS.API.Repositories;

namespace HRMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DashboardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("stats")]
        public IActionResult GetStats()
        {
            return Ok(_unitOfWork.Dashboard.GetStats());
        }

        [HttpGet("dept-distribution")]
        public IActionResult GetDeptDistribution()
        {
            return Ok(_unitOfWork.Dashboard.GetDeptDistribution());
        }
    }
}
