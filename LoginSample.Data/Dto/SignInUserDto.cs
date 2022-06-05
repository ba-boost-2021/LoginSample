using System.ComponentModel.DataAnnotations;

namespace LoginSample.Data.Dto
{
    public class SignInUserDto
    {
        [Required(ErrorMessage = "Mail Zorunludur")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Password Zorunludur")]
        public string Password { get; set; }
    }
}