﻿using BlogApp.Entities;
using BlogApp.Exceptions;
using BlogApp.Models;
using BlogApp.Models.User;
using BlogApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Register()
        {
            return View(new RegisterModel());
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (TryValidateModel(model))
            {
                var user = new User
                {
                    Email = model.Email,
                    UserName = model.Username
                };

                try
                {
                    _userService.CreateUser(user, model.Password);
                    _userService.SignIn(user);
                    return RedirectToAction("Index", "Home");
                }
                catch (CreateUserException ex)
                {
                    foreach (var exError in ex.Errors)
                    {
                        ModelState.AddModelError("createUser",exError);
                    }
                }
                
                return View(model);
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult SignIn()
        {
            return View(new SignInModel());
        }

        [HttpPost]
        public IActionResult SignIn(SignInModel model)
        {
            if (TryValidateModel(model))
            {
                try
                {
                    _userService.SignIn(model.Username, model.Password);
                    return RedirectToAction("Index", "Home");
                }
                catch (SignInUserException ex)
                {
                    foreach (var error in ex.Errors)
                    {
                        ModelState.AddModelError("signInError",error);
                    }
                }
            }
            
            return View(model);
        }

        public IActionResult SignOut()
        {
            _userService.SignOut();
            
            return RedirectToAction("Index", "Home");
        }
    }
}