﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApp.Entities
{
    public class Blog : BaseEntity
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}