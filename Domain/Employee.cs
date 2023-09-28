using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Employee
    {   
        [Key]
        public int Id { get; set; } 

        public string Name { get; set; }
        public string Email { get; set; }
        public string Job { get; set; }
        public double Salary { get; set; }
        public bool IsApporved { get; set; }

    }
}
