using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoWeb.Models;
using DemoWeb.Models.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoWeb.Data
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudents();

        Task CreateStudent(Student student);

        Task<StudentDto> GetStudent(int id);

        Task<bool> UpdateStudent(Student student);

        Task<bool> DeleteStudent(int id);

        Task DeleteStudent(Student student);
    }

    // You should move this to a separate file
    public class DatabaseStudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext _context;

        public DatabaseStudentRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task CreateStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteStudent(int id)
        {
            // Student student = await GetStudent(); // Doesn't work because GetStudent returns DTO
            Student student =  await _context.Students.FindAsync(id);
            if (student == null)
            {
                return false;
            }

            await DeleteStudent(student);
            return true;
        }

        public async Task DeleteStudent(Student student)
        {
            _context.Entry(student).State = EntityState.Deleted;
            // or _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAllStudents()
        {
            //return new[]
            //{
            //    new Student{FirstName = "Keith", LastName = "Dahlby"},
            //};

            return await _context.Students.ToListAsync();
        }

        public async Task<StudentDto> GetStudent(int id)
        {
            return await _context.Students
                //.Include(s => s.Transcripts)
                //.ThenInclude(t => t.Course)
                //.Include(s => s.Enrollments)
                //.ThenInclude(e => e.Course)
                // .FindAsync(id);
                .Select(student => new StudentDto
                {
                    StudentId = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,

                    // Sub-join select thing
                    CurrentCourses = student.Enrollments
                        .Select(e => new StudentCourseDto
                        {
                            CourseId = e.CourseId,
                            CourseCode = e.Course.CourseCode,
                        })
                        .ToList(),

                    Transcript = student.Transcripts
                        .Select(t => new TranscriptDto
                        {
                            StudentId = student.Id,
                            CourseId = t.Course.Id,
                            CourseCode = t.Course.CourseCode,
                            // TechnologyName = t.Course.Technology.Name,
                            Grade = t.Grade.ToString(),
                        })
                        .ToList(),
                })
                .FirstOrDefaultAsync(s => s.StudentId == id);
        }

        public async Task<bool> UpdateStudent(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                // Save worked
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(student.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
