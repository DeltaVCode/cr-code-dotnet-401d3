using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWeb.Models
{
    /// <summary>
    /// Represents the database model for a Course at DeltaV.
    /// </summary>
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string CourseCode { get; set; }

        // Option 2 to fix decimal warning, superseded by OnModelCreating
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        [Column(TypeName = "money")]
        public decimal? VeteranPrice { get; set; }


        // Reverse Navigation Property
        public List<Enrollment> Enrollments { get; set; }
    }
}
