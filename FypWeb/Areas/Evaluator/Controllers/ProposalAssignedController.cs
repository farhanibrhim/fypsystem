using Fyp.DataAccess.Data;
using Fyp.Models;
using Fyp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FypWeb.Areas.Evaluator.Controllers
{
    [Area("Evaluator")]
    [Authorize(Roles = SD.Role_Evaluator)]
    public class ProposalAssignedController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProposalAssignedController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: View proposals assigned
        public async Task<IActionResult> Index()
        {
            var evaluator = await _db.Evaluators
                .Include(e => e.ApplicationUser)
                .FirstOrDefaultAsync(e => e.ApplicationUser.UserName == User.Identity.Name);

            if (evaluator == null)
            {
                return NotFound();
            }

            var proposals = await _db.Proposals
                .Include(p => p.Murid)
                .ThenInclude(m => m.ApplicationUser)
                .Where(p => p.Evaluator1Id == evaluator.Id || p.Evaluator2Id == evaluator.Id)
                .ToListAsync();

            return View(proposals);
        }

        // GET: Evaluate proposal
        public async Task<IActionResult> Evaluate(int id)
        {
            var proposal = await _db.Proposals
                .Include(p => p.Murid)
                .ThenInclude(m => m.ApplicationUser)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (proposal == null)
            {
                return NotFound();
            }

            return View(proposal);
        }

        // POST: Save evaluation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Evaluate(int id, ProposalStatus status, string evaluatorComments)
        {
            var proposal = await _db.Proposals.FindAsync(id);

            if (proposal == null)
            {
                return NotFound();
            }

            var evaluator = await _db.Evaluators
                .Include(e => e.ApplicationUser)
                .FirstOrDefaultAsync(e => e.ApplicationUser.UserName == User.Identity.Name);

            if (evaluator == null)
            {
                return NotFound();
            }

            // Save comments and status based on evaluator identity
            if (proposal.Evaluator1Id == evaluator.Id)
            {
                proposal.Evaluator1Comments = evaluatorComments;
                proposal.Result1 = status;
                
            }
            else if (proposal.Evaluator2Id == evaluator.Id)
            {
                proposal.Evaluator2Comments = evaluatorComments;
                proposal.Result2 = status;
            }

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
