using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace ScheduleProg.Models
{
    public class Potok
    {
        public int Id { get; set; }
        public string Potok_Name{ get; set; }

        [ValidateNever]

        public List<Group> Groups { get; set; }
    }
}
