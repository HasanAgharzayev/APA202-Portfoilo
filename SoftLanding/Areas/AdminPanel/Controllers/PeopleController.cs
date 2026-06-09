using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftLanding.Areas.AdminPanel.ViewModels;
using SoftLanding.Data;
using SoftLanding.Models;
using SoftLanding.Utilities;
using SoftLanding.Utilities.Enums;
using System.Threading.Tasks;

namespace SoftLanding.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class PeopleController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public PeopleController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<GetPeopleVM> getPeopleVM = await _context.Teams
                .Where(p => !p.IsDeleted)
                .Select(p => new GetPeopleVM
                {
                    Id = p.Id,
                    Image = p.Image,
                    Name = p.Name,
                    Job = p.Job,
                    Description = p.Desc
                })
                .ToListAsync();

            return View(getPeopleVM);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreatePeopleVM createPeopleVM)
        {
            if(!ModelState.IsValid) return View(createPeopleVM);

            if (!createPeopleVM.Image.CheckType("image/"))
            {
                ModelState.AddModelError(nameof(createPeopleVM.Image), "file type is incoorecct");
                return View(createPeopleVM);
            }
            if (!createPeopleVM.Image.CheckSize(FileSize.Mb,2))
            {
                ModelState.AddModelError(nameof(createPeopleVM.Image), "file size is incoorecct");
                return View(createPeopleVM);
            }

            Team team = new()
            {
                Image = await createPeopleVM.Image.CreateFile(_env.WebRootPath, "images"),
                Name = createPeopleVM.Name,
                Job = createPeopleVM.Job,
                Desc = createPeopleVM.Description
            };

            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id is null || id < 1)
            {
                return BadRequest();
            }

            Team? team = await _context.Teams.FirstOrDefaultAsync(t => t.Id == id);

            if (team is null)
            {
                return NotFound();
            }

            UpdatePeopleVM updatePeopleVM = new() 
            { 
                Image = team.Image,
                Name = team.Name,
                Job = team.Job,
                Description = team.Desc
            };

            return View(updatePeopleVM);

        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, UpdatePeopleVM updatePeopleVM)
        {
            if (id is null || id < 1)
            {
                return BadRequest();
            }

            Team? team = await _context.Teams.FirstOrDefaultAsync(t => t.Id == id);

            if (team is null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(updatePeopleVM);
            }

            if (updatePeopleVM.Photo is not null)
            {
                if (!updatePeopleVM.Photo.CheckType("image/"))
                {
                    ModelState.AddModelError(nameof(updatePeopleVM.Photo), "file type is incoorecct");
                    return View(updatePeopleVM);
                }
                if (!updatePeopleVM.Photo.CheckSize(FileSize.Mb, 2))
                {
                    ModelState.AddModelError(nameof(updatePeopleVM.Photo), "file size is incoorecct");
                    return View(updatePeopleVM);
                }
                updatePeopleVM.Image.DeleteFile(_env.WebRootPath,"images");
                updatePeopleVM.Image = await updatePeopleVM.Photo.CreateFile(_env.WebRootPath, "images");
            }

            team.Name = updatePeopleVM.Name;
            team.Job = updatePeopleVM.Job;
            team.Desc = updatePeopleVM.Description;
            team.Image = updatePeopleVM.Image;

            _context.Teams.Update(team);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id < 1)
            {
                return BadRequest();
            }

            Team? team = await _context.Teams.FirstOrDefaultAsync(t => t.Id == id);

            if (team is null)
            {
                return NotFound();
            }

            team.Image.DeleteFile(_env.WebRootPath, "images");

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
