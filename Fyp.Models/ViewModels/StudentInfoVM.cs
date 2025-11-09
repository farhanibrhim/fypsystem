using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyp.Models.ViewModels
{
    public class StudentInfoVM
    {
        public ApplicationUser ApplicationUser { get; set; }

        public Murid Murid { get; set; }

        public Penyelia Supervisor { get; set; }

        public List<Penyelia> Supervisors { get; set; } // Add this property
    }
}


