using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyp.Models.ViewModels
{
    public class AssignProgramVM
    {
        public Pensyarah Lecturer { get; set; }
        public IEnumerable<SelectListItem> ProgramList { get; set; }
        public List<int> SelectedProgramIds { get; set; }
    }
}
