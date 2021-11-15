using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace VaccinationCampaignUI.Models
{
    public class Vaccine
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string DescriptionVacc { get; set; }

        [Required]
        public double Dose { get; set; }

        [Required]
        [MaxLength(40)]
        public string Manufacturer { get; set; }

        [Required]
        public int? DiseaseId { get; set; }

        [ForeignKey("DiseaseId")]
        public Disease Diseases { get; set; }
    }
}
