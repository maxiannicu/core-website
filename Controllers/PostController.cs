using BlogApp.Entities;
using BlogApp.Helpers;
using BlogApp.Models;
using BlogApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class PostController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IPostService _postService;

        public PostController(IBlogService blogService, IPostService postService)
        {
            _blogService = blogService;
            _postService = postService;
        }

        public IActionResult View(int id)
        {
            var post = _postService.GetById(id);
            if (post == null)
            {
                return NotFound();
            }
            
            return View(Mapping.EntityToModel(post));
        }

        public IActionResult Create(int blogId)
        {
            return View(new PostModel());
        }

        [HttpPost]
        public IActionResult Create(int blogId, PostModel model)
        {
            var blog = _blogService.Get(blogId);
            if (TryValidateModel(model) && blog != null)
            {
                var post = new Post();
                Mapping.ModelToEntity(model, post);
                post.Blog = blog;
                _postService.Insert(post);
                return RedirectToAction("View", "Blog", new
                {
                    id = blogId
                });
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var post = _postService.GetById(id);
            if (post == null)
                return NotFound();

            return View(Mapping.EntityToModel(post));
        }

        [HttpPost]
        public IActionResult Edit(int id, PostModel model)
        {
            if (TryValidateModel(model))
            {
                var post = _postService.GetById(id);
                if (post == null)
                    return NotFound();

                Mapping.ModelToEntity(model, post);
                _postService.Update(post);

                return RedirectToAction("View", new
                {
                    id = post.Id
                });
            }

            return View(model);
        }

        public IActionResult Remove(int id)
        {
            var post = _postService.GetById(id);
            if (post == null)
                return NotFound();
            _postService.Remove(id);
            return RedirectToAction("View", "Blog", new
            {
                id = post.BlogId
            });
        }
    }
}