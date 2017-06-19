using System.Collections.Generic;

namespace BlogApp.Models.Blog
{
    public class IndexModel
    {
        public IList<IndexEntryModel> Blogs { get; set; }
    }

    public class IndexEntryModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IndexEntryAuthorModel Author { get; set; }
    }

    public class IndexEntryAuthorModel
    {
        public string UserName { get; set; }
    }
}