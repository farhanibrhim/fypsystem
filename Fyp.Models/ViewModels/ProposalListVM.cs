using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Fyp.Models.ViewModels
{
    public class ProposalListVM
    {
        public List<Proposal> Proposals { get; set; }
        public string Semester { get; set; }
        public string AcademicSession { get; set; }
        public List<int> SelectedProgramIds { get; set; }
        public int? SelectedProjectTypeId { get; set; }  // Add this property
        public IEnumerable<SelectListItem> ProjectTypeList { get; set; }
    }

    public class AssignEvaluatorVM
    {
        public int MuridId { get; set; }
        public int ProposalId { get; set; }
        public int? Evaluator1Id { get; set; }
        public int? Evaluator2Id { get; set; }
        public List<SelectListItem> Evaluators { get; set; }
    }
}

