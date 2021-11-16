using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using VaccinationCampaignUI.Data;
using VaccinationCampaignUI.Models;


namespace VaccinationCampaignUI.Controllers
{
    public class VaccineController : Controller
    {
        private readonly ApplicationContext _context;
        public VaccineController(ApplicationContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var vaccine = _context.Vaccines.AsEnumerable();
            return View(vaccine);
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
        public async Task<IActionResult> Create(Vaccine vaccines)
        {
            await _context.Vaccines.AddAsync(vaccines);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var vaccine = await _context.Vaccines.FirstOrDefaultAsync(x => x.Id == id);
            return View(vaccine);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Vaccine vaccine)
        {
            _context.Entry(vaccine).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Vaccine vaccine = await _context.Vaccines.FirstOrDefaultAsync(x => x.Id == id);
            _context.Vaccines.Remove(vaccine);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
