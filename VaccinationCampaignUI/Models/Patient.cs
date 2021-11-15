using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace VaccinationCampaignUI.Models
{
    [Table("Patients")]
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        public bool Sex { get; set; }

        [Required]
        [MaxLength(15)]
        public string Passport { get; set; }

        [Required]
        public int? AddressId { get; set; }

        [ForeignKey("AddressId")]
        public Address Adress { get; set; }
    }
}
