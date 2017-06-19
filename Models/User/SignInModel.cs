using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models.User
{
    public class SignInModel
    {
        [MinLength(6)]
        public string Username { get; set; }
        
        [MinLength(6)]
        public string Password { get; set; }
    }
}