using Microsoft.AspNetCore.Mvc;
using HRMS.API.Repositories;
using System;

namespace HRMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnboardingController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public OnboardingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("request/{token}")]
        public IActionResult GetOnboardingRequest(Guid token)
        {
            return Ok(_unitOfWork.Onboarding.GetOnboardingRequest(token));
        }

        [HttpGet("pending")]
        public IActionResult GetPendingRequests()
        {
            return Ok(_unitOfWork.Onboarding.GetPendingRequests());
        }

        [HttpPost("submit")]
        public IActionResult SubmitOnboarding([FromBody] SubmitOnboardingRequest req)
        {
            _unitOfWork.Onboarding.SubmitOnboarding(req);
            return Ok(new { Message = "Onboarding details submitted successfully" });
        }
    }

    public class SubmitOnboardingRequest
    {
        public Guid Token { get; set; }
        public string PersonalDetails { get; set; }
    }
}
