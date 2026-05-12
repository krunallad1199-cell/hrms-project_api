using Microsoft.AspNetCore.Mvc;
using HRMS.API.Repositories;

namespace HRMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MasterController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("departments")]
        public IActionResult GetDepartments()
        {
            return Ok(_unitOfWork.Masters.GetDepartments());
        }

        [HttpGet("designations")]
        public IActionResult GetDesignations()
        {
            return Ok(_unitOfWork.Masters.GetDesignations());
        }
    }
}
