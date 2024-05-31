using Microsoft.AspNetCore.Identity;

namespace Demo_MVC.Models
{
	public class ApplicationUser: IdentityUser
	{
		public string Address { get; set; }
	}
}
