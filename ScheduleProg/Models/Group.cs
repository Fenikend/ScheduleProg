namespace ScheduleProg.Models
{
    public class Group
    {
        public int Id { get; set; }

        public string Course{ get; set; }

        public string Group_Name{ get; set; }

        public List<Pare> Pares { get; set; }
    }
}
