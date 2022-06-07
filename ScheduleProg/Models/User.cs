using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ScheduleProg.Models
{
    public class User : IdentityUser
    {
        
        public string? First_Name { get; set; }

        
        public string? Last_Name { get; set; }

        [ValidateNever]
        public Student Student { get; set; }
        [ValidateNever]
        public Teacher Teacher{ get; set; }

       
   

    }
}
