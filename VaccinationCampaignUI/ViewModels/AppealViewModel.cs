using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationCampaignUI.ViewModels
{
    public class AppealViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }
        public string Recommendation { get; set; }
        public string Doctor { get; set; }
        public DateTime Data { get; set; }
        public int PatientId { get; set; }

        public List<SelectViewModel> Patient { get; set; }
    }
}
