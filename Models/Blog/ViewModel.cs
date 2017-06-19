using System.Collections.Generic;

namespace BlogApp.Models.Blog
{
    public class ViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ViewAuthorModel Author { get; set; }
        public IList<ViewPostModel> Posts { get; set; }
    }

    public class ViewAuthorModel
    {
        public string UserName { get; set; }
    }
    
    public class ViewPostModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
    }
}