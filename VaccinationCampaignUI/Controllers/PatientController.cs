using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using VaccinationCampaignUI.Data;
using VaccinationCampaignUI.Models;

namespace VaccinationCampaignUI.Controllers
{
    public class PatientController : Controller
    {
        private readonly ApplicationContext _context;
        public PatientController(ApplicationContext context)
        {
            _context = context;
        }
        // GET: PatientController
        public IActionResult Index()
        {
            var patiets = _context.Patients.AsEnumerable();
            return View(patiets);
        }

        // GET: PatientController/Details/5
        public IActionResult Details(int id)
        {

            return View();
        }
        // GET: PatientController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PatientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // GET: PatientController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(x => x.Id == id);
            return View(patient);
        }

        // POST: PatientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Patient patient)
        {
            _context.Entry(patient).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // POST: PatientController/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Patient patient = await _context.Patients.FirstOrDefaultAsync(x => x.Id == id);
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
