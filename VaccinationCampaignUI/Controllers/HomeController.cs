using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VaccinationCampaignUI.Data;
using VaccinationCampaignUI.Models;

namespace VaccinationCampaignUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext _context;
        public HomeController(ApplicationContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View(_context.Addresses.ToList());
        }

        public IActionResult Diseases()
        {
            return View(_context.Diseases.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
