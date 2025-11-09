using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fyp.DataAccess.Data;
using Fyp.Models;
using Fyp.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using Fyp.Utility;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FypWeb.Areas.Committee.Controllers
{
    [Area("Lecturer")]
    [Authorize(Roles = SD.Role_Lecturer)]
    public class ProposalListController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProposalListController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Proposals
        public async Task<IActionResult> Index(string semester, string academicSession, int? selectedProjectTypeId)
        {
            var proposals = _context.Proposals
                .Include(p => p.ProjectType)
                .Include(p => p.Murid)
                .ThenInclude(m => m.ApplicationUser)
                .Include(p => p.Evaluator1)
                .ThenInclude(e => e.ApplicationUser)
                .Include(p => p.Evaluator2)
                .ThenInclude(e => e.ApplicationUser)
                .AsQueryable();

            if (!string.IsNullOrEmpty(semester))
            {
                proposals = proposals.Where(p => p.Murid.Semester == semester);
            }

            if (!string.IsNullOrEmpty(academicSession))
            {
                proposals = proposals.Where(p => p.Murid.AcademicSession == academicSession);
            }

            if (selectedProjectTypeId.HasValue)
            {
                proposals = proposals.Where(p => p.ProjectTypeId == selectedProjectTypeId.Value);
            }

            var projectTypeList = await _context.ProjectTypes
                .Select(pt => new SelectListItem
                {
                    Value = pt.Id.ToString(),
                    Text = pt.Name
                })
                .ToListAsync();

            var proposalListVM = new ProposalListVM
            {
                Proposals = await proposals.ToListAsync(),
                Semester = semester,
                AcademicSession = academicSession,
                SelectedProjectTypeId = selectedProjectTypeId,
                ProjectTypeList = projectTypeList
            };

            return View(proposalListVM);
        }


        // GET: Proposal Details
        public async Task<IActionResult> Details(int id)
        {
            var proposal = await _context.Proposals
                .Include(p => p.ProjectType)
                .Include(p => p.Murid)
                .ThenInclude(m => m.ApplicationUser)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (proposal == null)
            {
                return NotFound();
            }

            return View(proposal);
        }

        // GET: Assign Evaluators
        public async Task<IActionResult> AssignEvaluators(int id)
        {
            var proposal = await _context.Proposals
                .Include(p => p.Murid)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (proposal == null || proposal.Murid == null)
            {
                return NotFound();
            }

            var evaluators = await _context.Evaluators
                .Include(e => e.ApplicationUser)
                .Where(e => e.Id != proposal.Murid.SupervisorId)
                .ToListAsync();

            // Populate the Evaluators dropdown list
            var evaluatorList = evaluators
                .Where(e => e.ApplicationUser != null && e.ApplicationUser.Name != null)
                .Select(e => new SelectListItem
                {
                    Value = e.Id.ToString(),
                    Text = e.ApplicationUser.Name
                })
                .ToList();

            var assignEvaluatorVM = new AssignEvaluatorVM
            {
                ProposalId = proposal.Id,
                Evaluators = evaluatorList
            };

            return View(assignEvaluatorVM);
        }

        // POST: Assign Evaluators
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignEvaluators(AssignEvaluatorVM viewModel)
        {

                var proposal = await _context.Proposals
                    .Include(p => p.Murid)
                    .FirstOrDefaultAsync(p => p.Id == viewModel.ProposalId);

                if (proposal == null)
                {
                    return NotFound();
                }

                // Assuming you have a way to store evaluators for each proposal
                proposal.Evaluator1Id = viewModel.Evaluator1Id;
                proposal.Evaluator2Id = viewModel.Evaluator2Id;

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

        }
    }
}