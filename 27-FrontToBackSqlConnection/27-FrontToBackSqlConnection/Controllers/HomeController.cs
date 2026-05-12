
using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using _27_FrontToBackSqlConnection.Services;
using _27_FrontToBackSqlConnection.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace _27_FrontToBackSqlConnection.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        

        public HomeController(AppDbContext context)
        {
            _context = context;
            
        }

        public IActionResult Index()
        {

            List<Slider> sliders = _context.Sliders.Where(s=>!s.IsDeleted)
                .OrderBy(s=>s.Order)
                .Take(2)
                .ToList();


            List<Product> products= _context.Products
                 .Where(s => !s.IsDeleted)
                .Take(4)
                .Include(p=>p.ProductImages.Where(pi=>pi.IsPrimary!=null))
                .ToList();


            HomeVM homeVM = new()
            {
                Sliders = sliders,
                Products= products
            };
            return View(homeVM);
        }

    }
}
