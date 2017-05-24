﻿using System.Collections.Generic;
using System.Linq;
using BlogApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Repository
{
    public class BlogRepository : EfRepository<Blog>, IBlogRepository
    {
        public BlogRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public List<Blog> Get(int? skip = null, int? take = null)
        {
            var queryable = Table;
            if (skip.HasValue)
                queryable = queryable.Skip(skip.Value);
            if (take.HasValue)
                queryable = queryable.Take(take.Value);

            return queryable.ToList();
        }
    }
}