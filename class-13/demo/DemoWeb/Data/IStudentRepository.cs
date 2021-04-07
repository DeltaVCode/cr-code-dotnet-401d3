using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoWeb.Data
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudents();

        Task CreateStudent(Student student);
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

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            //return new[]
            //{
            //    new Student{FirstName = "Keith", LastName = "Dahlby"},
            //};

            return await _context.Students.ToListAsync();
        }
    }
}
