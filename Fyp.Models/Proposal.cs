using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyp.Models
{
    public enum ProposalStatus
    {
        Not_Submmitted_Yet,
        Pending,
        Accepted,
        AcceptedWithConditions,
        Rejected
    }

    public class Proposal
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [ForeignKey("ProjectType")]
        public int? ProjectTypeId { get; set; }
        public ProjectType ProjectType { get; set; }

        public string? ProposalDocumentUrl { get; set; }
        //public ProposalStatus Status { get; set; }
        public string? SupervisorComments { get; set; }
        public string? Evaluator1Comments { get; set; } // Comments from Evaluator 1
        public string? Evaluator2Comments { get; set; } // Comments from Evaluator 2
        public ProposalStatus? Result1 { get; set; }
        public ProposalStatus? Result2 { get; set; }
        public int MuridId { get; set; }
        public Murid Murid { get; set; } // Add this property to define the relationship

        public int? Evaluator1Id { get; set; }
        [ForeignKey("Evaluator1Id")]
        public Penilai Evaluator1 { get; set; }

        public int? Evaluator2Id { get; set; }
        [ForeignKey("Evaluator2Id")]
        public Penilai Evaluator2 { get; set; }
    }
}
