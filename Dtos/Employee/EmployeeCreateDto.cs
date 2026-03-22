using System.ComponentModel.DataAnnotations;

namespace User_Management_API.Dtos.Users
{
    public record EmployeeCreateDto
    {
        [Required(ErrorMessage = "Imię jest wymagane")]
        [StringLength(50, ErrorMessage = "Imię nie może przekraczać 50 znaków")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [StringLength(50, ErrorMessage = "Nazwisko nie może przekraczać 50 znaków")]
        public string LastName { get; set; }

        [Required]
        public int DepartmentID { get; set; }
    }
}
