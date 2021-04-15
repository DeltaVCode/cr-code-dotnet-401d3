using System.ComponentModel.DataAnnotations;

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

    /// <summary>
    /// Represents data needed to create a Transcript entry for some student.
    /// </summary>
    public class CreateTranscript
    {
        public int CourseId { get; set; }

        [Required]
        public string Grade { get; set; }
    }
}
