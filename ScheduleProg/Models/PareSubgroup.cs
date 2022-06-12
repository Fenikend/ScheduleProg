using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace ScheduleProg.Models
{
    public class PareSubgroup
    {
        public int Pare_Id { get; set; }
       

        public int Subgroup_Id{ get; set; }

        [ValidateNever]
        public string Week_Day { get { return (Pare.Week_Day); } }
        [ValidateNever]
        public Pare Pare { get; set; }
        [ValidateNever]
        public Subgroup Subgroup { get; set; }
    }
}
