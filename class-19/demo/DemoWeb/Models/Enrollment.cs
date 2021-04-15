namespace DemoWeb.Models
{
    public class Enrollment
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }

        // Navigation Properties
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
