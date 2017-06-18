using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class UserSignInModel
    {
        [MinLength(6)]
        public string Username { get; set; }
        
        [MinLength(6)]
        public string Password { get; set; }
    }
}