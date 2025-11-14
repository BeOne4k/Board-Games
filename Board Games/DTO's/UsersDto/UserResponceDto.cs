using System.ComponentModel.DataAnnotations;

namespace Board_Games.DTO_s.UsersDto
{
    public class UserResponceDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        [StringLength(20, ErrorMessage = "Name is too long!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Surname is required!")]
        [StringLength(20, ErrorMessage = "Surname is too long!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Age is required!")]
        [Range(14, 122, ErrorMessage = "Age must be between 14 and 122")]
        public int Age { get; set; }

        [Required(ErrorMessage = "City is required!")]
        [StringLength(50, ErrorMessage = "City name is too long!")]
        public string City { get; set; }
    }
}
