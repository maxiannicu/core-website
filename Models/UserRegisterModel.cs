using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class UserRegisterModel
    {
        [MinLength(6)]
        public string Username { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }

        [MinLength(6)]
        public string Password { get; set; }
        
    }
}