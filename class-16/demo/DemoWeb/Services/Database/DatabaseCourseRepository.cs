using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoWeb.Data;
using DemoWeb.Models;

namespace DemoWeb.Services.Database
{
    public class DatabaseCourseRepository : ICourseRepository
    {
        private readonly SchoolDbContext _context;

        public DatabaseCourseRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddStudentEnrollment(int courseId, int studentId)
        {
            // TODO: check if course/student exist; return false if they don't

            var enrollment = new Enrollment
            {
                CourseId = courseId,
                StudentId = studentId,
            };

            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteStudentEnrollment(int courseId, int studentId)
        {
            var enrollment = await _context.Enrollments.FindAsync(courseId, studentId);
            if (enrollment == null)
                return false;

            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
