using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationCampaignUI.Models
{
    public class Disease
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string NameDis { get; set; }

        [Required]
        public int Code { get; set; }

    }
}
