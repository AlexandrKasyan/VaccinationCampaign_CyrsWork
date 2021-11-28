using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationCampaignUI.ViewModels
{
    public class PatientViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }
        public bool Sex { get; set; }
        public string Passport { get; set; }
        public int AddressId { get; set; }

        public List<SelectViewModel> Addreses { get; set; }
    }
}
