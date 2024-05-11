using System.ComponentModel.DataAnnotations;

namespace Demo.PL.Models.User_DTO
{
    public class SignUpViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage ="Invalid Email Format")]
        public string Email { get; set; }
        [Required]
        [MaxLength(6)]
        public string Password { get; set; }
        [Required]
        [Compare(nameof(Password), ErrorMessage ="Password Doesn't Match")]
        public string ConfirmPassword { get; set; }
        [Required]
        public bool IsAgree { get; set; }
    }
}
