using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace ScheduleProg.Models
{
    public class PairTime
    {
        public int Id { get; set; }

        public string Begin_Time{ get; set; }

        public string End_Time { get; set; }
        [ValidateNever]
        public List<Pare> Pares { get; set; }

    }
}
