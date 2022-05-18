using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace ScheduleProg.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string First_Name{ get; set; }

        public string Last_Name { get; set; }

        public int Subgroup_Id { get; set; }

        public Subgroup Subgroup { get; set; }
        /*public int User_Id{ get; set; }*/

    }
}
