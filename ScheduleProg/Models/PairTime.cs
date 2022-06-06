using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace ScheduleProg.Models
{
    public class PairTime
    {
        public int Id { get; set; }

        public string Begin_Time { get; set; }

        public string End_Time { get; set; }

        public string Full_Time { get{ return (Begin_Time + '-' + End_Time); } }
        [ValidateNever]
        public List<Pare> Pares { get; set; }

    }
}
