namespace DemoWeb.Models
{
    public class Transcript
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        // Navigation properties to create our Foreign Keys
        public Student Student { get; set; }
        public Course Course { get; set; }

        public Grade Grade { get; set; }

        public bool Passed { get; set; }
    }
}
