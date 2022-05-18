using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace ScheduleProg.Models
{
    public class Subgroup
    {
        public int Id { get; set; }
        public string Subgr_Name { get; set; }

        public int Group_Id { get; set; }
        [ValidateNever]
        public Group Group { get; set; }
        [ValidateNever]
        public List<PareSubgroup> PareSubgroups { get; set; }
        [ValidateNever]
        public List<Student> Students { get; set; }
    }
}
