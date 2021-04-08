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
        Task<List<Student>> GetAllStudents();

        Task CreateStudent(Student student);

        Task<Student> GetStudent(int id);

        Task<bool> UpdateStudent(Student student);

        Task DeleteStudent(int id);
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

        public async Task DeleteStudent(int id)
        {
            Student student = await GetStudent(id);
            await DeleteStudent(student);
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

        public async Task<Student> GetStudent(int id)
        {
            return await _context.Students.FindAsync(id);
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
