using System.ComponentModel.DataAnnotations;

namespace Board_Games.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
    }
}
