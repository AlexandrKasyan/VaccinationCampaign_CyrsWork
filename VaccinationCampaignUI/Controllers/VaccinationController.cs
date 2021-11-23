using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccinationCampaignUI.Data;
using VaccinationCampaignUI.Models;
using VaccinationCampaignUI.ViewModels;

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
            var vaccinations = _context.Vaccinations.Include(x => x.Institution).Include(x => x.Patients).AsEnumerable();
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

        [HttpGet]
        public async Task<IActionResult> NumberVaccination(int cityId, int diseaseId) 
        {
            var citiesNames = _context.Addresses.Select(x => x);
            var cities = new List<SelectViewModel>();
            
            foreach (var item in citiesNames)
            {
                var actual = cities.Select(x => x.Name);
                if (!actual.Contains(item.Locality))
                {
                    cities.Add(new SelectViewModel { Id = item.Id, Name = item.Locality, });
                }
            }
            var diseases = await Task.Run(() => _context.Diseases.Select(x => new SelectViewModel { Id = x.Id, Name = x.NameDis }));

            var model = new NumberVaccinationViewModel
            {
                Cities = cities.ToList(),
                Diseases = diseases.ToList(),
            };

            if (cityId != 0 && diseaseId != 0)
            {
                var vaccines = _context.Vaccines.Where(x => x.DiseaseId == diseaseId).Select(x => x.Id);
                var allVaccinations = _context.Vaccinations.Select(x => x);
                var vaccinationsCount = allVaccinations.Where(x => vaccines.Contains(x.Id));

                var city = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == cityId);
                var selectedCitiesIds = _context.Addresses.Where(x => x.Locality.Equals(city.Locality)).Select(x => x.Id);
                var patients = _context.Patients.Where(x => selectedCitiesIds.Contains(x.Id)).Select(x => x.Id);

                var countResult = await vaccinationsCount.Where(x => patients.Contains(x.PatientId.Value)).CountAsync();
                model.Count = countResult;
            }


            return View(model); 
        }

    }
}

