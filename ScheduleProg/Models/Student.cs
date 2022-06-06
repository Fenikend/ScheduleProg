using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace ScheduleProg.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public int Subgroup_Id { get; set; }

        public String User_Id { get; set; }

        [ValidateNever]
        public Subgroup Subgroup { get; set; }

        [ValidateNever]

        public User User { get; set; }
        /*public int User_Id{ get; set; }*/

    }
}
