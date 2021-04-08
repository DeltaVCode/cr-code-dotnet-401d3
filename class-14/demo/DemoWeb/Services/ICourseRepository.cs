using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWeb.Services
{
    public interface ICourseRepository
    {
        // TODO: Get/Create/Delete go here

        Task<bool> AddStudentEnrollment(int courseId, int studentId);

        Task<bool> DeleteStudentEnrollment(int courseId, int studentId);
    }
}
