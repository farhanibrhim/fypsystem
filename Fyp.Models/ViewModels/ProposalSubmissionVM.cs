using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyp.Models.ViewModels
{
    public class ProposalSubmissionVM
    {
        public int MuridId { get; set; }
        public string Title { get; set; } = string.Empty; // Provide a default value if appropriate
        public int? ProjectTypeId { get; set; }

        [ValidateNever]
        public ProjectType ProjectType { get; set; }

        public IFormFile ProposalDocument { get; set; }
        public string ProposalDocumentUrl { get; set; } = string.Empty; // Provide a default value if appropriate
        public ProposalStatus? Result1 { get; set; } = ProposalStatus.Pending; // Set default status
        public ProposalStatus? Result2 { get; set; } = ProposalStatus.Pending;
        public string SupervisorComments { get; set; } = string.Empty; // Provide a default value if appropriate
        public string EvaluatorComments1 { get; set; } = string.Empty; // Provide a default value if appropriate
        public string EvaluatorComments2 { get; set; } = string.Empty; // Provide a default value if appropriate
        //public string? Result1 { get; set; } = ;
        //public string? Result2 { get; set; } = string.Empty;
    }

}


