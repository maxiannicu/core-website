using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models.User
{
    public class RegisterModel
    {
        [MinLength(6)]
        public string Username { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }

        [MinLength(6)]
        public string Password { get; set; }
        
    }
}