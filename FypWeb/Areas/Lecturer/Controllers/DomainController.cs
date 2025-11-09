using Fyp.DataAccess.Data;
using Fyp.Models;
using Fyp.Models.ViewModels;
using Fyp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Elfie.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FypWeb.Areas.Lecturer.Controllers
{
    [Area("Lecturer")]
    [Authorize(Roles = SD.Role_Lecturer)]
    public class DomainController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DomainController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecturer = _db.Lecturers.Include(l => l.ApplicationUser).FirstOrDefault(l => l.Id == id);

            if (lecturer == null)
            {
                return NotFound();
            }

            // Retrieve domains from the database
            var domains = _db.Domains.ToList();

            var vm = new EditDomainVM
            {
                Lecturer = lecturer,
                Domains = new SelectList(domains, "Id", "Name") // Pass "Id" and "Name" as the value and text field parameters
            };

            return View(vm);
        }


        [HttpPost]
        public IActionResult Edit(EditDomainVM model)
        {
            var lecturer = _db.Lecturers.FirstOrDefault(l => l.Id == model.Lecturer.Id);

            if (lecturer != null)
            {
                // Retrieve the domain from the database using the selected id
                var domain = _db.Domains.FirstOrDefault(d => d.Id == int.Parse(model.SelectedDomain));

                if (domain != null)
                {
                    // Assign the domain to lecturer.Domain
                    lecturer.Domain = domain;

                    _db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }



        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var lecturerList = _db.Lecturers
                .Include(l => l.ApplicationUser)
                .Include(l => l.LecturerPrograms)
                    .ThenInclude(lp => lp.AcademicProgram)
                .Include(l => l.Domain) // Include the Domain navigation property
                .Select(l => new
                {
                    id = l.Id,
                    name = l.ApplicationUser.Name,
                    program = string.Join(", ", l.LecturerPrograms.Select(lp => lp.AcademicProgram.Name)),
                    domain = l.Domain.Name // Uncomment this line
                }).ToList();

            return Json(new { data = lecturerList });
        }



        #endregion
    }
}
