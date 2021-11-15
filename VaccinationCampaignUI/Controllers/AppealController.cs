using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using VaccinationCampaignUI.Data;
using VaccinationCampaignUI.Models;


namespace VaccinationCampaignUI.Controllers
{
    public class AppealController : Controller
    {
        private readonly ApplicationContext _context;
        public AppealController(ApplicationContext context)
        {
            _context = context;
        }
        // GET: AppealController
        public IActionResult Index()
        {
            var appeals = _context.Appeals.AsEnumerable();
            return View(appeals);
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
        public async Task<IActionResult> Create(Appeal appeal)
        {
            await _context.Appeals.AddAsync(appeal);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // GET: AppealController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var appeal = await _context.Appeals.FirstOrDefaultAsync(x => x.Id == id);
            return View(appeal);
        }

        // POST: AppealController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Appeal appeal)
        {
            _context.Entry(appeal).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // POST: AppealController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Appeal appeal = await _context.Appeals.FirstOrDefaultAsync(x => x.Id == id);
            _context.Appeals.Remove(appeal);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
