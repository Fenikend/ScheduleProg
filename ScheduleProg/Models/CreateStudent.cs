using System.ComponentModel.DataAnnotations;

namespace ScheduleProg.Models
{
    public class CreateStudent
    {
        [Required]
        public string First_Name { get; set; }

        [Required]
        public string Last_Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public int Subgroup_Id{ get; set; }

        
    }
}
