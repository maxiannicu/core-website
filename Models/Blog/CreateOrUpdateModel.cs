using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models.Blog
{
    public class CreateOrUpdateModel
    {
        public int Id { get; set; }
        
        [MinLength(5),MaxLength(50)]
        public string Title { get; set; }
    }
}