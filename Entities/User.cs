using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BlogApp.Entities
{
    public class User : IdentityUser
    {
        public virtual IList<Blog> Blogs { get; set; }
    }
}