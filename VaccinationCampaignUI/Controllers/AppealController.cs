using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccinationCampaignUI.Data;
using VaccinationCampaignUI.Models;
using VaccinationCampaignUI.ViewModels;

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
        public async Task<IActionResult> Create()
        {

            var patient = await Task.Run(() => _context.Patients.Select(x => new SelectViewModel { Id = x.Id, Name = x.Name + " " + x.LastName + " " + x.Sex + " " + x.Passport}));
            var model = new AppealViewModel
            {
               Patient = patient.ToList(),
            };
            return View(model);
        }


        // POST: AppealController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppealViewModel model)
        {
            var appeal = new Appeal
            {
                PatientId = model.PatientId,
                Description = model.Description,
                Recommendation = model.Recommendation,
                Data = model.Data,
                Doctor = model.Doctor
            };

            await _context.Appeals.AddAsync(appeal);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // GET: AppealController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var appeal = await _context.Appeals.FirstOrDefaultAsync(x => x.Id == id);


            var patient = await Task.Run(() => _context.Patients.Select(x => new SelectViewModel { Id = x.Id, Name = x.Name + " " + x.LastName + " " + x.Sex + " " + x.Passport }));
            var model = new AppealViewModel
            {
                Id = appeal.Id,
                Description = appeal.Description,
                Recommendation = appeal.Recommendation,
                Data = appeal.Data,
                Doctor = appeal.Doctor,
                Patient = patient.ToList(),
            };
            return View(model);
        }

        // POST: AppealController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AppealViewModel model)
        {
            var appeal = await _context.Appeals.FirstOrDefaultAsync(x => x.Id == model.Id);


            appeal.PatientId = model.PatientId;
            appeal.Description = model.Description;
            appeal.Recommendation = model.Recommendation;
            appeal.Data = model.Data;
            appeal.Doctor = model.Doctor;

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

        [HttpGet]
        public async Task<IActionResult> CountAppeals(int regionId)
        {
            var addresses = _context.Addresses.Select(x => x);
            var regions = new List<SelectViewModel>();
            foreach (var item in addresses)
            {
                var actual = regions.Select(x => x.Name);
                if (!actual.Contains(item.Region))
                {
                    regions.Add(new SelectViewModel { Id = item.Id, Name = item.Region });
                }
            }

            var model = new CountAppealViewModel
            {
                Regions = regions.ToList(),
            };

            regionId = regionId == 0 ? regions.FirstOrDefault().Id : regionId;

            var region = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == regionId);
            var selectedRegionsIds = _context.Addresses.Where(x => x.Region.Equals(region.Region)).Select(x => x.Id);
            var patientsIds = _context.Patients.Where(x => selectedRegionsIds.Contains(x.Id)).Select(x => x.Id);

            var months = new List<string> { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };

            var result = new Dictionary<string, int>();
            var year = DateTime.Now.Year;
            for (int i = 1; i < DateTime.Now.Month; i++)
            {
                var dateStart = new DateTime(year, i, 1);
                var dateEnd = new DateTime(year, i + 1, 1);
                var appeals = await _context.Appeals.CountAsync(x => patientsIds.Contains(x.PatientId.Value)
                    && x.Data >= dateStart && x.Data < dateEnd);
                result.Add(months[i - 1], appeals);
            }
            model.Count = result;

            return View(model);
        }
    }
}
