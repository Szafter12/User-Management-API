using System.ComponentModel.DataAnnotations;

namespace User_Management_API.Dtos.Users
{
    public record UserCreateDto
    {
        [Required(ErrorMessage = "Imię jest wymagane.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Imię musi mieć od 2 do 50 znaków")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Imię jest wymagane.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Imię musi mieć od 2 do 50 znaków")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Adres Email jest wymagany")]
        [EmailAddress(ErrorMessage = "Niepoprawny format adresu email.")]
        public string Email { get; set; } = string.Empty;
    }
}
