
using System.Collections.Generic;
using System.Linq;
using BlogApp.Entities;
using BlogApp.Helpers;
using BlogApp.Models;
using BlogApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IPostService _postService;
        
        public BlogController(IBlogService blogService, IPostService postService)
        {
            _blogService = blogService;
            _postService = postService;
        }

        public IActionResult Index()
        {
            var blogs = _blogService.GetAll();
            return View(new BlogIndexModel
            {
                Blogs = blogs.Select(e => Mapping.EntityToModel(e)).ToList()
            });
        }

        public IActionResult View(int id)
        {
            var blog = _blogService.GetBlogWithPosts(id);
            if (blog == null)
                return NotFound();

            var blogViewModel = new BlogViewModel
            {
                Blog = Mapping.EntityToModel(blog),
                Posts = blog.Posts.Select(Mapping.EntityToModel).ToList()
            };
            return View(blogViewModel);
        }


        public IActionResult Create()
        {
            return View(new BlogModel());
        }

        [HttpPost]
        public IActionResult Create(BlogModel model)
        {
            if (TryValidateModel(model))
            {
                var blog = new Blog();
                Mapping.ModelToEntity(model,blog);
                _blogService.Insert(blog);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var blog = _blogService.Get(id);
            if (blog == null)
                return NotFound();

            return View(Mapping.EntityToModel(blog));
        }

        [HttpPost]
        public IActionResult Edit(int id,BlogModel model)
        {
            if (TryValidateModel(model))
            {
                var blog = _blogService.Get(id);
                if (blog == null)
                    return NotFound();

                Mapping.ModelToEntity(model,blog);
                _blogService.Update(blog);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Remove(int id)
        {
            _blogService.Remove(id);
            return RedirectToAction("Index");
        }

    }
}