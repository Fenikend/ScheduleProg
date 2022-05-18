using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace ScheduleProg.Models
{
    public class PareSubgroup
    {
        public int Pare_Id { get; set; }
        public Pare Pare { get; set; }

        public int Subgroup_Id{ get; set; }
        public Subgroup Subgroup { get; set; }
    }
}
