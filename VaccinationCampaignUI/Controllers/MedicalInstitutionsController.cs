using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using VaccinationCampaignUI.Data;
using VaccinationCampaignUI.Models;

namespace VaccinationCampaignUI.Controllers
{
    public class MedicalInstitutionsController : Controller
    {
        private readonly ApplicationContext _context;
        public MedicalInstitutionsController(ApplicationContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var institutions = _context.Institution.AsEnumerable();
            return View(institutions);
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
        public async Task<IActionResult> Create(MedicalInstitution institutions)
        {
            await _context.Institution.AddAsync(institutions);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var institutions = await _context.Institution.FirstOrDefaultAsync(x => x.Id == id);
            return View(institutions);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MedicalInstitution institutions)
        {
            _context.Entry(institutions).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            MedicalInstitution institutions = await _context.Institution.FirstOrDefaultAsync(x => x.Id == id);
            _context.Institution.Remove(institutions);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
