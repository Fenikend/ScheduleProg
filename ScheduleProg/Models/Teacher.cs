using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace ScheduleProg.Models
{
    public class Teacher 
    {
        public int Id { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public string User_Id { get; set; }

        [ValidateNever]
        public string Full_name { get { return (First_Name + Last_Name); }  }

        /*public int User_Id { get; set; }*/
        [ValidateNever]
        public List<Pare> Pares { get; set; }
        [ValidateNever]
        public User User { get; set; }
    }
}