using System.ComponentModel.DataAnnotations;

namespace Demo.PL.Models
{
    public class EmailViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }
    }
}
