using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0) return BadRequest("Invalid student ID.");

            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null) return NotFound("Student not found.");

            return Ok(student);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StudentDto studentDto)
        {
            if (studentDto == null) return BadRequest("Invalid student data.");
            if (string.IsNullOrWhiteSpace(studentDto.Name) || string.IsNullOrWhiteSpace(studentDto.Email))
                return BadRequest("Student name and email are required.");

            await _studentService.AddStudentAsync(studentDto);

            return CreatedAtAction(nameof(GetById), new { id = studentDto.Email }, studentDto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] StudentDto studentDto)
        {
            if (id <= 0) return BadRequest("Invalid student ID.");
            if (studentDto == null) return BadRequest("Invalid student data.");
            if (string.IsNullOrWhiteSpace(studentDto.Name) || string.IsNullOrWhiteSpace(studentDto.Email))
                return BadRequest("Student name and email are required.");

            await _studentService.UpdateStudentAsync(id, studentDto);
            return NoContent();
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Invalid student ID.");

            await _studentService.DeleteStudentAsync(id);
            return NoContent();
        }
    }
}
