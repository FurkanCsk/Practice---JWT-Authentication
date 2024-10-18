using System.ComponentModel.DataAnnotations;

namespace Practice_Identity_and_Data_Protection.Models
{
    public class LoginRequestModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
