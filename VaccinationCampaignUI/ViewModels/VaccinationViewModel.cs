using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationCampaignUI.ViewModels
{
    public class VaccinationViewModel
    {
        public int Id { get; set; }
        public string NameVaccine { get; set; }
        public DateTime Date { get; set; }
        public int MedicalInsId { get; set; }
        public int PatientId { get; set; }
        public int VaccineId { get; set; }

        public List<SelectViewModel> Patients { get; set; }
        public List<SelectViewModel> Vaccines { get; set; }
        public List<SelectViewModel> Institutions { get; set; }
    }
}
