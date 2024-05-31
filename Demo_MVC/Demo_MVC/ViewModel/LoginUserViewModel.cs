using System.ComponentModel.DataAnnotations;

namespace Demo_MVC.ViewModel
{
	public class LoginUserViewModel
	{
		public string UserName { get; set; }
		[DataType(DataType.Password)]
		public string Password { get; set; }
		public bool RememberMe { get; set; }
	}
}
