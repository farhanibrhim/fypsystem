using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyp.Models
{
    public class LecturerProgram
    {
        [Key, Column(Order = 0)]
        public int LecturerId { get; set; }
        public Pensyarah Lecturer { get; set; }

        [Key, Column(Order = 1)]
        public int AcademicProgramId { get; set; }
        public AcademicProgram AcademicProgram { get; set; }
    }
}
