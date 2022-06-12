using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace ScheduleProg.Models
{
    public class Pare
    {
        
        public int Id { get; set; }

        public int Subject_Id { get; set; }

        public int Semester_Id { get; set; }
        public int Teacher_Id { get; set; }

        public int Pair_Time_Id { get; set; }

        public string Week_Day  { get; set; }

     

        [ValidateNever]
        public string Description { get { return (PairTime.Full_Time+' '+Week_Day + ' '  + Subject.Discipline_Name ); } }
        
        [ValidateNever]
        public Semester Semester  { get; set; }
        [ValidateNever]
        public List<PareSubgroup> PareSubgroups { get; set; }
        [ValidateNever]
        public Subject Subject { get; set; }
        [ValidateNever]
        public Teacher Teacher{ get; set; }
        [ValidateNever]
        public PairTime PairTime{ get; set; }

        [ValidateNever]
        public List<Teacher> Teachers { get; set; }
    }
}
