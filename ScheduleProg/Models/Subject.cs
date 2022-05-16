using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ScheduleProg.Models
{
    public class Subject
    {
        public  int Id { get; set; }
        public string Discipline_Name{ get; set; }

        [ValidateNever]
        public List<Pare> Pares { get; set; }
    }
}
