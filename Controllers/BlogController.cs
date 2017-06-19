
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BlogApp.Entities;
using BlogApp.Helpers;
using BlogApp.Models;
using BlogApp.Models.Blog;
using BlogApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        
        public BlogController(IBlogService blogService, IPostService postService, IMapper mapper)
        {
            _blogService = blogService;
            _postService = postService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var blogs = _blogService.GetAll();
            return View(new IndexModel
            {
                Blogs = blogs.Select(s => _mapper.Map<IndexEntryModel>(s)).ToList()
            });
        }

        public IActionResult View(int id)
        {
            var blog = _blogService.GetBlogWithPosts(id);
            if (blog == null)
                return NotFound();

            return View(_mapper.Map<ViewModel>(blog));
        }


        public IActionResult Create()
        {
            return View(new CreateOrUpdateModel());
        }

        [HttpPost]
        public IActionResult Create(CreateOrUpdateModel model)
        {
            if (TryValidateModel(model))
            {
                var blog = _mapper.Map<Blog>(model);
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

            return View(_mapper.Map<CreateOrUpdateModel>(blog));
        }

        [HttpPost]
        public IActionResult Edit(int id,CreateOrUpdateModel model)
        {
            if (TryValidateModel(model))
            {
                var blog = _blogService.Get(id);
                if (blog == null)
                    return NotFound();

                _mapper.Map(model, blog);
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