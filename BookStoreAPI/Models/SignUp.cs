using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Models
{
    public class SignUpModel
    {
        [Required]
        public string ?FirstName { get; set; }
        [Required]
        public string ?LastName { get; set; }
        [Required]
        [EmailAddress]
        public string ?email { get; set; }

        [Required]
        public string ?Password { get; set; }
    }
}
