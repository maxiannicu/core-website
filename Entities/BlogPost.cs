using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApp.Entities
{
    public class BlogPost : BaseEntity
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}