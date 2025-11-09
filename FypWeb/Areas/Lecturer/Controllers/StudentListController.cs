using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fyp.DataAccess.Data;
using Fyp.Models;
using Fyp.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fyp.Utility;

namespace Fyp.Areas.Lecturer.Controllers
{
    [Area("Lecturer")]
    [Authorize(Roles = SD.Role_Lecturer)]
    public class StudentListController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentListController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(Enum? status)
        {
            var students = await _context.Students
                .Include(m => m.Supervisor)
                .ThenInclude(s => s.ApplicationUser)
                .Include(m => m.ApplicationUser)
                .ToListAsync();

            var viewModel = students.Select(m => new SupervisorApprovalVM
            {
                MuridId = m.StudentId,
                StudentName = m.ApplicationUser.Name,
                SupervisorName = m.Supervisor?.ApplicationUser?.Name ?? "Not Assigned",
                SupervisorApprovalStatus = m.SupervisorApprovalStatus
            }).ToList();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ApproveSupervisor(int muridId)
        {
            var murid = await _context.Students.FindAsync(muridId);
            if (murid != null)
            {
                murid.SupervisorApprovalStatus = SupervisorApprovalStatus.Approved;
                _context.Update(murid);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RejectSupervisor(int muridId)
        {
            var murid = await _context.Students.FindAsync(muridId);
            if (murid != null)
            {
                murid.SupervisorApprovalStatus = SupervisorApprovalStatus.Rejected;
                murid.SupervisorId = null;  // Remove the supervisor ID
                _context.Update(murid);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> SetPendingSupervisor(int muridId)
        {
            var murid = await _context.Students.FindAsync(muridId);
            if (murid != null)
            {
                murid.SupervisorApprovalStatus = SupervisorApprovalStatus.Pending;
                _context.Update(murid);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}