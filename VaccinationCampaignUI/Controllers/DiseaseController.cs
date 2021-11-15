using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using VaccinationCampaignUI.Data;
using VaccinationCampaignUI.Models;


namespace VaccinationCampaignUI.Controllers
{
    public class DiseaseController : Controller
    {
        private readonly ApplicationContext _context;
        public DiseaseController(ApplicationContext context)
        {
            _context = context;
        }
        // GET: AppealController
        public IActionResult Index()
        {
            var diseases = _context.Diseases.AsEnumerable();
            return View(diseases);
        }

        // GET: AppealController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: AppealController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AppealController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Disease diseases)
        {
            await _context.Diseases.AddAsync(diseases);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // GET: AppealController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var diseases = await _context.Diseases.FirstOrDefaultAsync(x => x.Id == id);
            return View(diseases);
        }

        // POST: AppealController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Disease diseases)
        {
            _context.Entry(diseases).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // POST: AppealController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Disease diseases = await _context.Diseases.FirstOrDefaultAsync(x => x.Id == id);
            _context.Diseases.Remove(diseases);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
