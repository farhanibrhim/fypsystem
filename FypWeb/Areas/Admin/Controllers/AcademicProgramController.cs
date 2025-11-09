using Fyp.DataAccess.Repository.IRepository;
using Fyp.Models;
using Fyp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FypWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class AcademicProgramController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AcademicProgramController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<AcademicProgram> objAPList = _unitOfWork.AcademicProgram.GetAll().ToList();
            return View(objAPList);
        }

        public IActionResult Create() { return View(); }

        [HttpPost]
        public IActionResult Create(AcademicProgram obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.AcademicProgram.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "New Program created successfully!";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            AcademicProgram academicProgramFromDb = _unitOfWork.AcademicProgram.Get(u => u.Id == id);

            if (academicProgramFromDb == null)
            {
                return NotFound();
            }

            return View(academicProgramFromDb);
        }

        [HttpPost]
        public IActionResult Edit(AcademicProgram obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.AcademicProgram.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Program updated successfully!";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            AcademicProgram academicProgramFromDb = _unitOfWork.AcademicProgram.Get(u => u.Id == id);

            if (academicProgramFromDb == null)
            {
                return NotFound();
            }

            return View(academicProgramFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            AcademicProgram? obj = _unitOfWork.AcademicProgram.Get(u => u.Id == id);

            if(obj == null)
            {
                return NotFound();
            }

            _unitOfWork.AcademicProgram.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Program deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
