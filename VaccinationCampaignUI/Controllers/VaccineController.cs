using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using VaccinationCampaignUI.Data;
using VaccinationCampaignUI.Models;
using VaccinationCampaignUI.ViewModels;

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
            var vaccine = _context.Vaccines.Include(x => x.Diseases).AsEnumerable();
            return View(vaccine);
        }

        public IActionResult Details(int id)
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var disease = await Task.Run(() => _context.Diseases.Select(x => new SelectViewModel { Id = x.Id, Name = x.NameDis + " " + x.Code}));
           
            var model = new VaccineViewModel
            {
                Diseases = disease.ToList()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VaccineViewModel model)
        {

            var vaccines = new Vaccine
            {
                DescriptionVacc = model.DescriptionVacc,
                Dose = model.Dose,
                Manufacturer = model.Manufacturer,
                DiseaseId = model.DiseaseId,
            };

            await _context.Vaccines.AddAsync(vaccines);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var vaccine = await _context.Vaccines.FirstOrDefaultAsync(x => x.Id == id);


            var disease = await Task.Run(() => _context.Diseases.Select(x => new SelectViewModel { Id = x.Id, Name = x.NameDis + " " + x.Code }));
            var model = new VaccineViewModel
            {
                Id = vaccine.Id,
                DescriptionVacc = vaccine.DescriptionVacc,
                Dose = vaccine.Dose,
                Manufacturer = vaccine.Manufacturer,
                Diseases = disease.ToList(),
            };
            return View(model);
         
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(VaccineViewModel model)
        {

            var vaccine = await _context.Vaccines.FirstOrDefaultAsync(x => x.Id == model.Id);

            vaccine.DescriptionVacc = model.DescriptionVacc;
            vaccine.Dose = model.Dose;
            vaccine.Manufacturer = model.Manufacturer;
            vaccine.DiseaseId = model.DiseaseId;

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
