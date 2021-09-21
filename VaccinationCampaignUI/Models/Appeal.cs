using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationCampaignUI.Models
{
    public class Appeal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Description { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        [MaxLength(80)]
        public string Recommendation { get; set; }

        [Required]
        [MaxLength(60)]
        public string Doctor { get; set; }


        [Required]
        public int PatientId { get; set; }

        [ForeignKey("PatientId")]
        public Patient Patients { get; set; }

    }
}
