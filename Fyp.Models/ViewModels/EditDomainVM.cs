using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyp.Models.ViewModels
{
    public class EditDomainVM
    {
        public Pensyarah Lecturer { get; set; }
        public SelectList Domains { get; set; }
        public string SelectedDomain { get; set; }
    }

}
