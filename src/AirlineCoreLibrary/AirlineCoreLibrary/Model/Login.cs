using System.ComponentModel.DataAnnotations;

namespace AirlineCoreLibrary.Model
{
    public class Login
    {
        [Required(ErrorMessage = "Username must be supply!")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password must be supply!")]
        public string? Password { get; set; }

        public bool? Remember { get; set; }
    }
}
