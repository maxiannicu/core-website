﻿using AutoMapper;
using BlogApp.Entities;
using BlogApp.Helpers;
using BlogApp.Models;
using BlogApp.Models.Post;
using BlogApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class PostController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostController(IBlogService blogService, IPostService postService, IMapper mapper)
        {
            _blogService = blogService;
            _postService = postService;
            _mapper = mapper;
        }

        public IActionResult View(int id)
        {
            var post = _postService.GetById(id);
            if (post == null)
            {
                return NotFound();
            }
            
            return View(_mapper.Map<ViewModel>(post));
        }

        public IActionResult Create(int blogId)
        {
            return View(new CreateOrUpdateModel());
        }

        [HttpPost]
        public IActionResult Create(int blogId, CreateOrUpdateModel model)
        {
            var blog = _blogService.Get(blogId);
            if (TryValidateModel(model) && blog != null)
            {
                var post = new Post();
                _mapper.Map(model, post);
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

            return View(_mapper.Map<CreateOrUpdateModel>(post));
        }

        [HttpPost]
        public IActionResult Edit(int id, CreateOrUpdateModel model)
        {
            if (TryValidateModel(model))
            {
                var post = _postService.GetById(id);
                if (post == null)
                    return NotFound();

                _mapper.Map(model, post);
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