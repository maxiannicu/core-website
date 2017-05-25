using System.Collections.Generic;

namespace BlogApp.Models
{
    public class BlogViewModel
    {
        public BlogModel Blog { get; set; }
        public List<PostModel> Posts { get; set; }
    }
}