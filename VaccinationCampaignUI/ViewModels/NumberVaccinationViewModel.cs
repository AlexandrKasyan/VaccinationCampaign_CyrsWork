using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationCampaignUI.ViewModels
{
    public class NumberVaccinationViewModel
    {
        public List<SelectViewModel> Cities { get; set; }
        public List<SelectViewModel> Diseases { get; set; }

        public int Count { get; set; }
    }
}
