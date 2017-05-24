using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class BlogModel
    {
        public int Id { get; set; }
        [MinLength(10),MaxLength(50)]
        public string Title { get; set; }
        [MinLength(4),MaxLength(50)]
        public string Author { get; set; }
    }
}