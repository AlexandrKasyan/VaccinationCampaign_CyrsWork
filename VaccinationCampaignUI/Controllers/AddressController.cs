using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using VaccinationCampaignUI.Data;
using VaccinationCampaignUI.Models;

namespace VaccinationCampaignUI.Controllers
{
    public class AddressController : Controller
    {
        private readonly ApplicationContext _context;

        public AddressController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: AddressController
        public IActionResult Index()
        {
            var addresses = _context.Addresses.AsEnumerable();
            return View(addresses);
        }

        // GET: AddressController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddressController/Create
        [HttpPost]
        public async Task<IActionResult> Create(Address address)
        {
            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: AddressController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == id);
            return View(address);
        }

        // POST: AddressController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Address address)
        {
            _context.Entry(address).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));           
        }


        // POST: AddressController/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Address address = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == id);
            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
