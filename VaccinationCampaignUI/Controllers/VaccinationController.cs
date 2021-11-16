using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using VaccinationCampaignUI.Data;
using VaccinationCampaignUI.Models;

namespace VaccinationCampaignUI.Controllers
{
    public class VaccinationController : Controller
    {
        private readonly ApplicationContext _context;
        public VaccinationController(ApplicationContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var vaccinations = _context.Vaccinations.AsEnumerable();
            return View(vaccinations);
        }

        public IActionResult Details(int id)
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vaccination vaccination)
        {
            await _context.Vaccinations.AddAsync(vaccination);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var vaccination = await _context.Vaccinations.FirstOrDefaultAsync(x => x.Id == id);
            return View(vaccination);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Vaccination vaccination)
        {
            _context.Entry(vaccination).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Vaccination vaccination = await _context.Vaccinations.FirstOrDefaultAsync(x => x.Id == id);
            _context.Vaccinations.Remove(vaccination);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}

