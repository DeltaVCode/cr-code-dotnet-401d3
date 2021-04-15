using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWeb.Models.Api
{
    public class TranscriptDto
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public string CourseCode { get; set; }
        public string TechnologyName { get; set; }

        public string Grade { get; set; }
    }
}
