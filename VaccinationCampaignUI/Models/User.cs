using Microsoft.AspNetCore.Identity;

namespace VaccinationCampaignUI.Models
{
	public class User : IdentityUser
	{
		public int Year { get; set; }
	}
}
