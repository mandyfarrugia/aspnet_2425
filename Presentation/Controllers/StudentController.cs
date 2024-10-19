using DataAccess.Repositories;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class StudentController : Controller
    {
        private StudentsRepository StudentsRepository { get; }

        public StudentController(StudentsRepository _studentsRepository)
        {
            this.StudentsRepository = _studentsRepository;
        }

        public IActionResult Index()
        {
            List<Student> students = this.StudentsRepository.GetStudents().ToList();
            return View(students);
        }

        public IActionResult Create()
        {
            Student student = new Student();
            return View(student);
        }

        public IActionResult Delete(string id)
        {
            try
            {
                this.StudentsRepository.DeleteStudent(id);
                TempData["message"] = $"{id} has been deleted successfully.";
            }
            catch (Exception)
            {
                TempData["error"] = "Could not delete! The user could not be found or the data was tampered with. Please make sure to provide a valid ID number.";
            }

            return RedirectToAction("Index", "Student");
        }
    }
}
