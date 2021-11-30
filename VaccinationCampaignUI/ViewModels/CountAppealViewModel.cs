using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationCampaignUI.ViewModels
{
    public class CountAppealViewModel
    {
        public List<SelectViewModel> Regions { get; set; }
        public Dictionary<string, int> Count { get; set; }
        
    }
}
