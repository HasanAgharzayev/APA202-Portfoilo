using Microsoft.AspNetCore.Mvc;

namespace _25_MVC_Intro.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            


            var student = new JsonResult(new
            {
                Id = 1,
                Name = "John Doe",
                Age = 20
            });
            return student;

        }

        public IActionResult Detail(int? id)
        {
            if(id is null || id < 1)
            {
                return RedirectToAction("Error");
            }
            return View();
        }



        public string Error()
        {
            return "Error";
        }
    }
}
