using System.ComponentModel.DataAnnotations;

namespace Practice_Identity_and_Data_Protection.Models
{
    public class RegisterRequestModel
    {
        [Required]
        [EmailAddress]
        [MinLength(10)]
        public string Email { get; set; }

        [Required]
        [Length(5, 20)]
        public string Password { get; set; }
    }
}
