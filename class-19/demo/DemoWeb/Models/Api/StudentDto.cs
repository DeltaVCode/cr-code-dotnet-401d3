using System.Collections.Generic;

namespace DemoWeb.Models.Api
{
    public class StudentDto
    {
        public int StudentId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }


        public List<TranscriptDto> Transcript { get; set; }

        public List<StudentCourseDto> CurrentCourses { get; set; }
    }

    public class StudentCourseDto
    {
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string TechnologyName { get; set; }
    }
}
