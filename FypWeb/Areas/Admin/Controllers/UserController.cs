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
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;

        public UserController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }


        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<ApplicationUser> objUserList = _db.ApplicationUsers.Include(u => u.Lecturer).ToList();

            var userRoles = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();

            foreach (var user in objUserList)
            {
                if (user.LecturerId != null)
                {
                    user.Role = "Lecturer";
                }
                else if (user.EvaluatorId != null)
                {
                    user.Role = "Evaluator";
                }
                else if (user.SupervisorId!= null)
                {
                    user.Role = "Supervisor";
                }
                else if (user.StudentId != null)
                {
                    user.Role = "Student";
                }
                else
                {
                    user.Role = "Admin";
                }
            }

            return Json(new { data = objUserList }); // Return objUserList as data
        }



        [HttpPost]
        public IActionResult Delete(string id)
        {
            var user = _db.ApplicationUsers
                .Include(u => u.Lecturer)
                .Include(u => u.Evaluator)
                .Include(u => u.Student)
                .Include(u => u.Supervisor)
                .FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }

            var lecturer = user.Lecturer;
            if (lecturer != null)
            {
                _db.Lecturers.Remove(lecturer);
            }

            var evaluator = user.Evaluator;
            if (evaluator != null)
            {
                _db.Evaluators.Remove(evaluator);
            }

            var stud = user.Student;
            if (stud != null)
            {
                _db.Students.Remove(stud);
            }

            var super = user.Supervisor;
            if (super != null)
            {
                _db.Supervisors.Remove(super);
            }

            _db.ApplicationUsers.Remove(user);
            _db.SaveChanges();
            return Json(new { success = true, message = "Delete Successful" });
        }


        [HttpPost]
        public IActionResult LockUnlock([FromBody] string id)
        {
            var objFromDb = _db.ApplicationUsers.FirstOrDefault(u => u.Id == id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while Locking/Unlocking" });
            }

            if (objFromDb.LockoutEnd != null && objFromDb.LockoutEnd > DateTime.Now)
            {
                objFromDb.LockoutEnd = DateTime.Now;
            }
            else
            {
                objFromDb.LockoutEnd = DateTime.Now.AddYears(1000);
            }

            _db.SaveChanges();
            return Json(new { success = true, message = "Operation Successful" });
        }

        #endregion
    }
}
