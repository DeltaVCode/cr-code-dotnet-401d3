using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoWeb.Data;
using DemoWeb.Models;
using DemoWeb.Models.Api;

namespace DemoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly SchoolDbContext _context;
        private readonly IStudentRepository studentRepository;

        public StudentsController(SchoolDbContext context, IStudentRepository studentRepository)
        {
            _context = context;
            this.studentRepository = studentRepository;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            IEnumerable<Student> students = await studentRepository.GetAllStudents();
            //return new ActionResult<IEnumerable<Student>>(students);
            //return new ActionResult<IEnumerable<Student>>(Ok(students));
            return Ok(students);

            //IEnumerable<Student> students = await _context.Students.ToListAsync();
            //return students;
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetStudent(int id)
        {
            var student = await studentRepository.GetStudent(id);

            if (student == null)
            {
                //return new ActionResult<Student>(NotFound());
                return NotFound(); // Implicit conversion to ActionResult<Student>
            }

            // return new ActionResult<Student>(student);
            return student; // Implicit conversion to ActionResult<Student>
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            if (!await studentRepository.UpdateStudent(student))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            await studentRepository.CreateStudent(student);

            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            if (!await studentRepository.DeleteStudent(id))
            {
                return NotFound();
            }

            //var student = await studentRepository.GetStudent(id);
            //if (student == null)
            //{
            //    return NotFound();
            //}

            //await studentRepository.DeleteStudent(student);

            return NoContent();
        }
    }
}
