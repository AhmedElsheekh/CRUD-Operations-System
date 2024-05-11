using System.ComponentModel.DataAnnotations;

namespace Demo.PL.Models
{
	public class ResetPasswordViewModel
	{
		[Required(ErrorMessage = "Password Can't Be Blank")]
		[MaxLength(6)]
		public string Password { get; set; }
		[Required]
		[MaxLength(6)]
		[Compare(nameof(Password), ErrorMessage = "Password Doesn't Match")]
		public string ConfirmPassword { get; set; }
		public string Email { get; set; }
		public string Token { get; set; }
	}
}
