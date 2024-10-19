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
    }
}
