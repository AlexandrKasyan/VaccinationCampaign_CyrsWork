using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationCampaignUI.ViewModels
{
    public class VaccineViewModel
    {
        public int Id { get; set; }
        public string DescriptionVacc { get; set; }
        public double Dose { get; set; }
        public string Manufacturer  { get; set; }
        public int DiseaseId { get; set; }
        public List<SelectViewModel> Diseases { get; set; }
    }
}
