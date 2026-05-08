using _27_FrontToBackSqlConnection.Services;
using Microsoft.AspNetCore.Mvc;

namespace _27_FrontToBackSqlConnection.Controllers
{
    public class ShopController: Controller
    {
        private readonly IEmailService _emailService;

        public ShopController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            _emailService.SendEmail();

            return View();
        }
    }
}
