using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccinationCampaignUI.Models;

namespace VaccinationCampaignUI.ViewModels
{
    public class PatientVaccinations
    {
        public IQueryable<Vaccination> Vaccinations { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }


    }
}
