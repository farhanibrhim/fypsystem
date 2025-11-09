using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyp.Models.ViewModels
{
    public class StudentDetailsVM
    {
        public List<Murid> Students { get; set; }
        public string Semester { get; set; }
        public string AcademicSession { get; set; }
    }
}

