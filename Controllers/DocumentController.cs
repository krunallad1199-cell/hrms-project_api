using Microsoft.AspNetCore.Mvc;
using HRMS.API.Repositories;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Hosting;

namespace HRMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;

        public DocumentController(IUnitOfWork unitOfWork, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _env = env;
        }

        [HttpGet("{employeeId}")]
        public IActionResult GetDocuments(int employeeId)
        {
            return Ok(_unitOfWork.Documents.GetDocumentsByEmployee(employeeId));
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadDocument([FromForm] int employeeId, [FromForm] string documentType, [FromForm] IFormFile file)
        {
            try 
            {
                if (file == null || file.Length == 0)
                {
                    Console.WriteLine("Upload Error: No file provided in the request.");
                    return BadRequest("No file uploaded.");
                }

                Console.WriteLine($"Uploading file: {file.FileName} for Employee ID: {employeeId}");

                string uploadsFolder = Path.Combine(_env.ContentRootPath, "wwwroot", "uploads");
                if (!Directory.Exists(uploadsFolder))
                {
                    Console.WriteLine($"Creating uploads directory at: {uploadsFolder}");
                    Directory.CreateDirectory(uploadsFolder);
                }

                string fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var doc = new
                {
                    EmployeeId = employeeId,
                    DocumentType = documentType,
                    FileName = file.FileName,
                    FilePath = "/uploads/" + fileName
                };

                int docId = _unitOfWork.Documents.SaveDocument(doc);
                Console.WriteLine($"File saved successfully. Database ID: {docId}");

                return Ok(new { Id = docId, Message = "Document uploaded successfully" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"FATAL ERROR in UploadDocument: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDocument(int id)
        {
            _unitOfWork.Documents.DeleteDocument(id);
            return Ok(new { Message = "Document deleted successfully" });
        }
    }
}
