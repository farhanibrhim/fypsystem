using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyp.Models.ViewModels
{
    public class ChangeCommitteeStatusVM
    {
        public ApplicationUser ApplicationUser { get; set; }
        public Pensyarah Lecturer { get; set; }
    }
}
