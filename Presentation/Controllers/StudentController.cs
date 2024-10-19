using DataAccess.Repositories;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models.ViewModels;

namespace Presentation.Controllers
{
    public class StudentController : Controller
    {
        private StudentsRepository StudentsRepository { get; }
        private GroupsRepository GroupsRepository { get; }

        public StudentController(StudentsRepository _studentsRepository, GroupsRepository _groupsRepository)
        {
            this.StudentsRepository = _studentsRepository;
            this.GroupsRepository = _groupsRepository;
        }

        public IActionResult Index()
        {
            List<Student> students = this.StudentsRepository.GetStudents().ToList();
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateStudentViewModel createStudentViewModel = new CreateStudentViewModel(this.GroupsRepository);
            return View(createStudentViewModel);
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
