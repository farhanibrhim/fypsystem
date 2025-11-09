using Fyp.DataAccess.Data;
using Fyp.DataAccess.Repository.IRepository;
using Fyp.Models;
using Fyp.Models.ViewModels;
using Fyp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FypWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class LecturerController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;

        public LecturerController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ChangeCommitteeStatus(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Assuming you have a context object for database operations
            var lecturer = _db.Lecturers.Include(l => l.ApplicationUser).FirstOrDefault(l => l.Id == id);

            if (lecturer == null)
            {
                return NotFound();
            }

            ChangeCommitteeStatusVM vm = new ChangeCommitteeStatusVM()
            {
                ApplicationUser = lecturer.ApplicationUser,
                Lecturer = lecturer
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult ChangeCommitteeStatus(ChangeCommitteeStatusVM model)
        {
            //if (ModelState.IsValid)
            //{
                // Assuming you have a context object for database operations
                var lecturer = _db.Lecturers.FirstOrDefault(l => l.Id == model.Lecturer.Id);

                if (lecturer != null)
                {
                    lecturer.IsCommitteeMember = model.Lecturer.IsCommitteeMember;

                    _db.SaveChanges();

                    return RedirectToAction("Index"); // Redirect to the list view
                }
            //}

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public IActionResult AssignProgram(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecturer = _db.Lecturers
                .Include(l => l.ApplicationUser)
                .Include(l => l.LecturerPrograms)
                    .ThenInclude(lp => lp.AcademicProgram)
                .FirstOrDefault(l => l.Id == id);

            if (lecturer == null)
            {
                return NotFound();
            }

            var programs = _db.AcademicPrograms.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            });

            // Get all assigned programs
            var assignedPrograms = lecturer.LecturerPrograms.Select(lp => lp.AcademicProgramId).ToList();

            AssignProgramVM vm = new AssignProgramVM()
            {
                Lecturer = lecturer,
                ProgramList = programs,
                SelectedProgramIds = assignedPrograms
            };

            return View(vm);
        }



        [HttpPost]
        public IActionResult AssignProgram(AssignProgramVM model)
        {
            var lecturer = _db.Lecturers.Include(l => l.LecturerPrograms).FirstOrDefault(l => l.Id == model.Lecturer.Id);

            if (lecturer != null)
            {
                // Remove all existing assignments
                _db.LecturerPrograms.RemoveRange(lecturer.LecturerPrograms);

                // Check if any programs are selected
                if (model.SelectedProgramIds != null)
                {
                    foreach (var programId in model.SelectedProgramIds)
                    {
                        var program = _db.AcademicPrograms.FirstOrDefault(p => p.Id == programId);

                        if (program != null)
                        {
                            // Add new assignments
                            _db.LecturerPrograms.Add(new LecturerProgram { LecturerId = lecturer.Id, AcademicProgramId = program.Id });
                        }
                    }
                }

                _db.SaveChanges();

                return RedirectToAction("Index"); // Redirect to the list view
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            // Retrieve only users with a LecturerId
            var objUserList = _db.ApplicationUsers
                .Include(u => u.Lecturer)
                .ThenInclude(l => l.LecturerPrograms)
                .ThenInclude(lp => lp.AcademicProgram)
                .Where(u => u.LecturerId != null)
                .Select(u => new
                {
                    // Select only the properties you need
                    id = u.Id,
                    name = u.Name,
                    isCommitteeMember = u.Lecturer.IsCommitteeMember,
                    lecturerId = u.LecturerId,
                    programs = u.Lecturer.LecturerPrograms.Select(lp => lp.AcademicProgram.Name).ToList()
                })
                .ToList();

            return Json(new { data = objUserList }); // Return objUserList as data
        }



        [HttpPost]
        public IActionResult Delete(string id)
        {
            var user = _db.ApplicationUsers.Include(u => u.Lecturer).FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }

            var lecturer = user.Lecturer;
            if (lecturer != null)
            {
                _db.Lecturers.Remove(lecturer);
            }

            _db.ApplicationUsers.Remove(user);
            _db.SaveChanges();
            return Json(new { success = true, message = "Delete Successful" });
        }


        #endregion
    }
}
