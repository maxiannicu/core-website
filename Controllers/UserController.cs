using BlogApp.Entities;
using BlogApp.Exceptions;
using BlogApp.Models;
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
            return View(new UserRegisterModel());
        }

        [HttpPost]
        public IActionResult Register(UserRegisterModel model)
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
            return View(new UserSignInModel());
        }

        [HttpPost]
        public IActionResult SignIn(UserSignInModel model)
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
                    ModelState.AddModelError("signInError",ex.Message);
                }
            }
            
            return View(model);
        }
    }
}