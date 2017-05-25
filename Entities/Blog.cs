using System.Collections.Generic;

namespace BlogApp.Entities
{
    public class Blog : BaseEntity
    {
        public Blog()
        {
            Posts = new List<Post>();
        }

        public string Author { get; set; }
        public string Title { get; set; }
        public virtual List<Post> Posts { get; set; }
    }
}