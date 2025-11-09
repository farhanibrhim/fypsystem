using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fyp.DataAccess.Data;
using Fyp.Models;
using Fyp.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using Fyp.Utility;

namespace FypWeb.Areas.Supervisor.Controllers
{
    [Area("Supervisor")]
    [Authorize(Roles = SD.Role_Supervisor)]
    public class StudentDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: View own students based on semester and academic session
        public async Task<IActionResult> Index(string semester = null, string academicSession = null)
        {
            var supervisor = await _context.Supervisors
                .Include(s => s.ApplicationUser)
                .Include(s => s.Students)
                .ThenInclude(m => m.Proposal)
                .ThenInclude(p => p.ProjectType)
                .FirstOrDefaultAsync(s => s.ApplicationUser.UserName == User.Identity.Name);

            if (supervisor == null)
            {
                return NotFound();
            }

            // Initialize students query
            var students = _context.Students
                .Include(m => m.ApplicationUser)
                .Include(m => m.Proposal)
                .ThenInclude(p => p.ProjectType)
                .Where(m => m.SupervisorId == supervisor.Id && m.SupervisorApprovalStatus == SupervisorApprovalStatus.Approved); // Filter by supervisor's ID and approval status

            // Apply filters based on provided semester and academicSession
            if (!string.IsNullOrEmpty(semester))
            {
                students = students.Where(m => m.Semester == semester);
            }

            if (!string.IsNullOrEmpty(academicSession))
            {
                students = students.Where(m => m.AcademicSession == academicSession);
            }

            // Execute query and prepare view model
            var viewModel = new StudentDetailsVM
            {
                Students = await students.ToListAsync(), // Execute query here
                Semester = semester ?? string.Empty,
                AcademicSession = academicSession ?? string.Empty
            };

            return View(viewModel);
        }




        // GET: View student proposal and leave comments before evaluator assessment
        public async Task<IActionResult> ProposalDetails(int id)
        {
            var proposal = await _context.Proposals
                .Include(p => p.Murid)
                .ThenInclude(m => m.ApplicationUser)
                .Include(p => p.ProjectType)
                .Include(p => p.Evaluator1)
                .Include(p => p.Evaluator2)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (proposal == null)
            {
                return NotFound();
            }

            return View(proposal);
        }

        // POST: Leave comments before evaluator assessment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LeaveComments(int id, string supervisorComments)
        {
            var proposal = await _context.Proposals.FindAsync(id);

            if (proposal == null)
            {
                return NotFound();
            }

            proposal.SupervisorComments = supervisorComments;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(ProposalDetails), new { id });
        }

        // GET: View evaluation results and evaluator comments
        public async Task<IActionResult> EvaluationResults(int id)
        {
            var proposal = await _context.Proposals
                .Include(p => p.Murid)
                .ThenInclude(m => m.ApplicationUser)
                .Include(p => p.Evaluator1)
                .Include(p => p.Evaluator2)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (proposal == null)
            {
                return NotFound();
            }

            return View(proposal);
        }
    }
}
