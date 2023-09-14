using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.Models
{
    public class SignInModel
    {
        [Required(ErrorMessage ="Pls enter email")]
        public string ?email { get; set; }

        [Required(ErrorMessage = "Pls enter password")]
        public string ?password { get; set; }
    }
}
