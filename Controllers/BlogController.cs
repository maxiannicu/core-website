
using System.Linq;
using BlogApp.Entities;
using BlogApp.Models;
using BlogApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            var blogs = _blogService.GetAll();
            return View(new BlogIndexModel
            {
                Blogs = blogs.Select(e => EntityToModel(e)).ToList()
            });
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
                ModelToEntity(model,blog);
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

            return View(EntityToModel(blog));
        }

        [HttpPost]
        public IActionResult Edit(int id,BlogModel model)
        {
            if (TryValidateModel(model))
            {
                var blog = _blogService.Get(id);
                if (blog == null)
                    return NotFound();

                ModelToEntity(model,blog);


                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Remove(int id)
        {
            _blogService.Remove(id);
            return RedirectToAction("Index");
        }

        private static BlogModel EntityToModel(Blog blog)
        {
            return new BlogModel
            {
                Id = blog.Id,
                Author = blog.Author,
                Title = blog.Title
            };
        }

        private static void ModelToEntity(BlogModel model,Blog entity)
        {
            entity.Author = model.Author;
            entity.Title = model.Title;
        }

    }
}