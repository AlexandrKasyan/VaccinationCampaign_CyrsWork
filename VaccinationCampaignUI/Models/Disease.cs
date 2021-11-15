using System.ComponentModel.DataAnnotations;


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
