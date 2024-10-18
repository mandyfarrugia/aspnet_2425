using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
