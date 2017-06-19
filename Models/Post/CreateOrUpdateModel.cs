using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models.Post
{
    public class CreateOrUpdateModel
    {
        public int Id { get; set; }
        
        [MinLength(5),MaxLength(50)]
        public string Title { get; set; }
        
        [MinLength(50)]
        public string ShortDescription { get; set; }
        
        [MinLength(150)]
        public string FullDescription { get; set; }
    }
}