using System.ComponentModel.DataAnnotations;

namespace Demo.PL.Models.User_DTO
{
	public class SignInViewModel
	{
		[Required(ErrorMessage ="Email Can't Be Blank")]
		[EmailAddress(ErrorMessage = "Invalid Email Format")]
		public string Email { get; set; }
		[Required(ErrorMessage ="Password Can't Be Blank")]
		[MaxLength(6)]
		public string Password { get; set; }
		public bool RememberMe { get; set; }
	}
}
