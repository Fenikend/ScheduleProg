using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace ScheduleProg.Models
{
    public class Pare
    {
        public int Id { get; set; }
        public int Group_Id { get; set; }

        public int Subject_Id { get; set; }

        public int Semester_Id { get; set; }
        public int Teacher_Id { get; set; }

        public int Pair_Time_Id { get; set; }

      
        public Semester Semester  { get; set; }

        public List<PareSubgroup> PareSubgroups { get; set; }

        public Subject Subject { get; set; }

        public Teacher Teacher{ get; set; }

        public PairTime PairTime{ get; set; }
    }
}
