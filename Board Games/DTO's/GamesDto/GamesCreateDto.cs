using System.ComponentModel.DataAnnotations;

namespace Board_Games.DTO_s.GamesDto
{
    public class GamesCreateDto
    {
        

        [Required(ErrorMessage = "GamesName is required!")]
        [StringLength(20, ErrorMessage = "GamesName is too long!")]
        public string GamesName { get; set; }

        [Required(ErrorMessage = "Discription  is required!")]
        [StringLength(20, ErrorMessage = "Discription  is too long!")]
        public string Discription { get; set; }

        [Required(ErrorMessage = "Price is required!")]
        [Range(100, 1000, ErrorMessage = "Price must be between 100 and 1000")]
        public int Price { get; set; }
    }
}
