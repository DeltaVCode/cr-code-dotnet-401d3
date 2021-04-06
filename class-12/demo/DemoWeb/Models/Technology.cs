using System.ComponentModel.DataAnnotations;

namespace DemoWeb.Models
{
    public class Technology
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }
    }
}
