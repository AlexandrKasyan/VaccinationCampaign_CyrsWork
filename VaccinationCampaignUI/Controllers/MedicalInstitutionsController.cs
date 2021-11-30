using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using VaccinationCampaignUI.Data;
using VaccinationCampaignUI.Models;
using VaccinationCampaignUI.ViewModels;

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

        public async Task<IActionResult> Create()
        {
            var appeal = await Task.Run(() => _context.Appeals.Select(x => new SelectViewModel { Id = x.Id, Name = x.Data.ToShortDateString() + " " + x.Description }));

            var model = new MedicalInstitutionViewModel
            {
                Appeal = appeal.ToList()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(MedicalInstitutionViewModel model)
        {

            var institutions = new MedicalInstitution
            {
                NameMedInst = model.NameMedInst,
                AdressMedInst = model.AdressMedInst,
                AppealId = model.AppealId,
            };
            await _context.Institution.AddAsync(institutions);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var institutions = await _context.Institution.FirstOrDefaultAsync(x => x.Id == id);


            var appeal = await Task.Run(() => _context.Appeals.Select(x => new SelectViewModel { Id = x.Id, Name = x.Data.ToShortDateString() + " " + x.Description }));
            var model = new MedicalInstitutionViewModel
            {
                Id = institutions.Id,
                NameMedInst = institutions.NameMedInst,
                AdressMedInst = institutions.AdressMedInst,
                Appeal = appeal.ToList(),
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MedicalInstitutionViewModel model)
        {

            var institutions = await _context.Institution.FirstOrDefaultAsync(x => x.Id == model.Id);

            institutions.NameMedInst = model.NameMedInst;
            institutions.AdressMedInst = model.AdressMedInst;
            institutions.AppealId = model.AppealId;


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
