using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace ScheduleProg.Models
{
    public class PareSubgroup
    {
        public int Pare_Id { get; set; }
       

        public int Subgroup_Id{ get; set; }
        [ValidateNever]
        public Pare Pare { get; set; }
        [ValidateNever]
        public Subgroup Subgroup { get; set; }
    }
}
