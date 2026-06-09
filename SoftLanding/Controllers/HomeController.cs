using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftLanding.Data;
using SoftLanding.Models;

namespace SoftLanding.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext context;

        public HomeController(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Team> teams = await context.Teams.Where(t => !t.IsDeleted).ToListAsync();

            return View(teams);
        }

    }
}
