using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationCampaignUI.Models
{
    [Table("Addresses")]
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Coutry { get; set; }

        [Required]
        [MaxLength(25)]
        public string Region { get; set; }

        [Required]
        [MaxLength(25)]
        public string Locality { get; set; }

        [Required]
        [MaxLength(10)]
        public string Hous { get; set; }

        [Required]
        public int Flat { get; set; }
    }
}
