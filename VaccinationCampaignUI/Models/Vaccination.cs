using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationCampaignUI.Models
{
    public class Vaccination
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string NameVaccine { get; set; }


        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int NamberDose { get; set; }

        [Required]
        public int? PatientId { get; set; }

        [ForeignKey("PatientId")]
        public Patient Patients { get; set; }

        [Required]
        public int? VaccineId { get; set; }

        [ForeignKey("VaccineId")]
        public Vaccine VaccineN { get; set; }

        [Required]
        public int? MedicalInsId { get; set; }

        [ForeignKey("MedicalInsId")]
        public MedicalInstitution Institution { get; set; }
    }
}
