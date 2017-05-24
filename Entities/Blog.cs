using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlogApp.Entities
{
    public class Blog : BaseEntity
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public List<BlogPost> Posts { get; set; }
    }
}