using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace ScheduleProg.Models
{
    public class Semester
    {
        public int Id { get; set; } 

        public DateTime Begin_Date { get; set; }

        public DateTime End_Date { get; set; }

        public List<Pare> Pares { get; set; }

    }
}
