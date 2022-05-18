﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace ScheduleProg.Models
{
    public class Group
    {
        public int Id { get; set; }

        public string Course{ get; set; }

        public string Group_Name{ get; set; }

        public int Potok_Id{ get; set; }

        public Potok Potok { get; set; }


        public List<Subgroup> Subgroups { get; set; }
    }
}