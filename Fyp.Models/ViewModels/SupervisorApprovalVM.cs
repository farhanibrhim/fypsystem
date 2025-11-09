using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyp.Models.ViewModels
{
    public class SupervisorApprovalVM
    {
        public int MuridId { get; set; }
        public string StudentName { get; set; }

        public string SupervisorName { get; set; }
        public SupervisorApprovalStatus SupervisorApprovalStatus { get; set; }
    }
}

