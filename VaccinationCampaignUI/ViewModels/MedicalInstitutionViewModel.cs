using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationCampaignUI.ViewModels
{
    public class MedicalInstitutionViewModel
    {
        public int Id { get; set; }
        public string NameMedInst { get; set; }
        public string AdressMedInst { get; set; }
        public int? AppealId { get; set; }
        public List<SelectViewModel> Appeal { get; set; }

    }
}
