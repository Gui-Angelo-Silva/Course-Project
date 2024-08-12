using backend.Objects.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace backend.Objects.DTOs.Entities
{
    public class Login
    {
        [Required(ErrorMessage = "O e-mail é requerido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é requerida!")]
        public string Password { get; set; }
    }
}