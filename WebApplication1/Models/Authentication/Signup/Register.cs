using System.ComponentModel.DataAnnotations;

namespace Web1.Models.Authentication.Signup
{
    public class Register
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
