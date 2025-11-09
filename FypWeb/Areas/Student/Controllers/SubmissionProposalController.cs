using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fyp.DataAccess.Data;
using Fyp.Models;
using Fyp.Models.ViewModels;
using Fyp.Utility;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FypWeb.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize(Roles = SD.Role_Student)]
    public class SubmissionProposalController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SubmissionProposalController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: View for submitting a new proposal
        public async Task<IActionResult> Index()
        {
            var murid = await _context.Students
                .Include(m => m.Proposal)
                .Include(m => m.ApplicationUser)
                .FirstOrDefaultAsync(m => m.ApplicationUser.UserName == User.Identity.Name);

            if (murid == null)
            {
                return NotFound();
            }

            if (murid.SupervisorApprovalStatus == SupervisorApprovalStatus.Pending ||
                murid.SupervisorApprovalStatus == SupervisorApprovalStatus.Not_Submitted_Yet ||
                murid.SupervisorApprovalStatus == SupervisorApprovalStatus.Rejected)
            {
                TempData["NoSupervisorAssigned"] = "You need to select your supervisor before you can submit a proposal and wait until your approval status is approved.";
                return RedirectToAction("Index", "StudentInfo"); // Or any other appropriate action
            }

            int? projectTypeId = murid.Proposal?.ProjectTypeId;
            var projtype = projectTypeId.HasValue
                ? await _context.ProjectTypes.FirstOrDefaultAsync(u => u.Id == projectTypeId.Value)
                : null;

            var viewModel = new ProposalSubmissionVM
            {
                MuridId = murid.StudentId,
                Title = murid.Proposal?.Title ?? string.Empty,
                ProjectTypeId = murid.Proposal?.ProjectTypeId,
                ProposalDocumentUrl = murid.Proposal?.ProposalDocumentUrl ?? string.Empty,
                Result1 = murid.Proposal?.Result1 ?? ProposalStatus.Not_Submmitted_Yet,
                Result2 = murid.Proposal?.Result2 ?? ProposalStatus.Not_Submmitted_Yet,
                SupervisorComments = murid.Proposal?.SupervisorComments ?? string.Empty,
                EvaluatorComments1 = murid.Proposal?.Evaluator1Comments ?? string.Empty,
                EvaluatorComments2 = murid.Proposal?.Evaluator2Comments ?? string.Empty,
                ProjectType = projtype
            };

            ViewBag.ProjectTypes = new SelectList(await _context.ProjectTypes.ToListAsync(), "Id", "Name");

            return View(viewModel);
        }


        // POST: Submit a new proposal
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(ProposalSubmissionVM viewModel)
        {
            if (ModelState.IsValid)
            {
                var murid = await _context.Students
                    .Include(m => m.Proposal)
                    .FirstOrDefaultAsync(m => m.StudentId == viewModel.MuridId);

                if (murid == null)
                {
                    return NotFound();
                }

                string uniqueFileName = null;
                if (viewModel.ProposalDocument != null)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "proposals");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + viewModel.ProposalDocument.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await viewModel.ProposalDocument.CopyToAsync(fileStream);
                    }
                }

                if (murid.Proposal == null)
                {
                    murid.Proposal = new Proposal();
                    _context.Proposals.Add(murid.Proposal);
                }

                murid.Proposal.Title = viewModel.Title;
                murid.Proposal.ProjectTypeId = viewModel.ProjectTypeId;
                if (uniqueFileName != null)
                {
                    murid.Proposal.ProposalDocumentUrl = uniqueFileName;
                }
                murid.Proposal.Result1 = ProposalStatus.Pending;
                murid.Proposal.Result2 = ProposalStatus.Pending;

                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            // If ModelState is not valid, reload the view with the existing ViewModel and project types
            ViewBag.ProjectTypes = new SelectList(await _context.ProjectTypes.ToListAsync(), "Id", "Name");
            return View("Index", viewModel);
        }

        // GET: Resubmit proposal form
        public async Task<IActionResult> Resubmit(int id)
        {
            var proposal = await _context.Proposals.FindAsync(id);

            if (proposal == null)
            {
                return NotFound();
            }

            var viewModel = new ProposalSubmissionVM
            {
                MuridId = proposal.Id,
                Title = proposal.Title,
                ProjectTypeId = proposal.ProjectTypeId,
                ProposalDocumentUrl = proposal.ProposalDocumentUrl,
                Result1 = proposal.Result1,
                Result2 = proposal.Result2,
                SupervisorComments = proposal.SupervisorComments,
                EvaluatorComments1 = proposal.Evaluator1Comments,
                EvaluatorComments2 = proposal.Evaluator2Comments
            };

            ViewBag.ProjectTypes = new SelectList(await _context.ProjectTypes.ToListAsync(), "Id", "Name");

            return View("Index", viewModel);
        }
    }
}
