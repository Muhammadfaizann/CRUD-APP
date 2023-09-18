using System.ComponentModel.DataAnnotations;

namespace ServerApplication.Models.UserModels
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string Token { get; set; } = default!;
    }
}
