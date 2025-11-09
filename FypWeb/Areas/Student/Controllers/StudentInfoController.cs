using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Fyp.Models.ViewModels;
using System.Threading.Tasks;
using Fyp.Models;
using Fyp.Utility;
using Microsoft.AspNetCore.Authorization;
using Fyp.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Fyp.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize(Roles = SD.Role_Student)]
    public class StudentInfoController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public StudentInfoController(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var applicationUser = user as ApplicationUser;
            var student = await _context.Students
                .Include(s => s.Supervisor)
                .FirstOrDefaultAsync(s => s.StudentId == applicationUser.StudentId);

            if (student == null)
            {
                return NotFound("Student not found.");
            }

            var supervisors = await _context.Supervisors.Include(s => s.ApplicationUser).ToListAsync();

            var model = new StudentInfoVM
            {
                ApplicationUser = applicationUser,
                Murid = student,
                Supervisors = supervisors
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(StudentInfoVM model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var applicationUser = user as ApplicationUser;
            var student = await _context.Students.FirstOrDefaultAsync(s => s.StudentId == applicationUser.StudentId);

            if (student == null)
            {
                return NotFound("Student not found.");
            }

            // Update application user details
            applicationUser.StreetAddress = model.ApplicationUser.StreetAddress;
            applicationUser.IcNumber = model.ApplicationUser.IcNumber;
            applicationUser.PhoneNumber = model.ApplicationUser.PhoneNumber;
            applicationUser.Gender = model.ApplicationUser.Gender;
            applicationUser.Nationality = model.ApplicationUser.Nationality;

            // Check if supervisor is being changed and update approval status
            if (student.SupervisorId != model.Murid.SupervisorId)
            {
                student.SupervisorId = model.Murid.SupervisorId;
                student.SupervisorApprovalStatus = SupervisorApprovalStatus.Pending; // Update status to Pending
            }

            student.Semester = model.Murid.Semester;
            student.AcademicSession = model.Murid.AcademicSession;

            _context.Update(applicationUser);
            _context.Update(student);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
