using System.ComponentModel.DataAnnotations;

namespace Secretary.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 8, ErrorMessage = "You just specify as password between 8 and 25 characters")]
        public string Password { get;  set; }
    }
}