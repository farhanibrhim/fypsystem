using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Fyp.Models
{
    public enum SupervisorApprovalStatus
    {
        Not_Submitted_Yet,
        Pending,
        Approved,
        Rejected
    }

    public class Murid
    {
        [Key] // Indicate that StudentId is the primary key
        public int StudentId { get; set; }

        public int? SupervisorId { get; set; }
        public Penyelia Supervisor { get; set; }

        public int? ProposalId { get; set; }
        public Proposal Proposal { get; set; }

        [ForeignKey("StudentId")]
        public ApplicationUser ApplicationUser { get; set; }

        public string? Semester { get; set; }

        public string? AcademicSession { get; set; }

        public SupervisorApprovalStatus SupervisorApprovalStatus { get; set; } // Add this property
    }
}

