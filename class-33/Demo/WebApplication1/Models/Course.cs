using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Display(Name = "Course Code")]
        [Required, StringLength(50)]
        public string CourseCode { get; set; }

        [Column(TypeName = "money")]
        [Display(Name ="Course Price")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:N1}")]
        public double? Rating { get; set; }
    }
}
