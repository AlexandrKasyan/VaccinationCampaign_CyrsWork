using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationCampaignUI.Models
{
    public class MedicalInstitution
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string NameMedInst { get; set; }

        [Required]
        [MaxLength(60)]
        public string AdressMedInst { get; set; }

        [Required]
        public int? AppealId { get; set; }

        [ForeignKey("AppealId")]
        public Appeal Appeall { get; set; }

    }
}
