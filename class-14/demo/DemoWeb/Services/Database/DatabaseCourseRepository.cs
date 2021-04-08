using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoWeb.Data;

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
            return true;
        }

        public async Task<bool> DeleteStudentEnrollment(int courseId, int studentId)
        {
            return true;
        }
    }
}
