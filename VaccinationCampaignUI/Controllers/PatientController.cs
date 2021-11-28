using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using VaccinationCampaignUI.Data;
using VaccinationCampaignUI.Models;
using VaccinationCampaignUI.ViewModels;

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
            var patiets = _context.Patients.Include(x => x.Adress).AsEnumerable();
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


            var addreses = await Task.Run(() => _context.Addresses.Select(x => new SelectViewModel { Id = x.Id, Name = x.Coutry +" "+  x.Region + " " + x.Locality + " " + x.Hous + " " + x.Flat.ToString() }));
            var model = new PatientViewModel
            { 
                Id = patient.Id,
                Name = patient.Name,
                LastName = patient.LastName,
                Sex = patient.Sex,
                Passport = patient.Passport,
                Addreses = addreses.ToList(),
            };
            return View(model);


        }

        // POST: PatientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PatientViewModel model)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(x => x.Id == model.Id);

            patient.AddressId = model.AddressId;
            patient.Name = model.Name;
            patient.LastName = model.LastName;
            patient.Sex = model.Sex;
            patient.Passport = model.Passport;
            
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

        public async Task<IActionResult> FindPatient(int id)
        {
            var vaccination = await Task.Run(() => _context.Vaccinations.Include(x => x.Institution).Where(x => x.PatientId == id));
            var patient = await _context.Patients.FirstOrDefaultAsync(x => x.Id == id);
            var model = new PatientVaccinations
            {
                Name = patient.Name,
                LastName = patient.LastName,
                Vaccinations = vaccination
            };
            
            return View(model);
        }
    }
}
