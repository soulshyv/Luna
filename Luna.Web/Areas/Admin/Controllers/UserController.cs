using System;
using System.Threading.Tasks;
using Autofac;
using Luna.Commons.Authentication;
using Luna.Commons.Models;
using Luna.Commons.Models.Identity;
using Luna.Mvc;
using Luna.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Luna.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : BaseController
    {
        private LunaUserManager _userManager;
        private LunaUserManager UserManager => _userManager ??= _scope.Resolve<LunaUserManager>();
        
        private LunaDbContext _lunaDbContext;
        private LunaDbContext LunaDbContext => _lunaDbContext ??= _scope.Resolve<LunaDbContext>();
        
        public UserController(ILifetimeScope scope) : base(scope)
        {
        }

        public async Task<IActionResult> Index()
        {
            var users = await LunaDbContext.Users.ToArrayAsync();
            
            return View(users);
        }
        
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View(new UserViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            var checkUser = await UserManager.FindByEmailAsync(model.Email);

            if (checkUser != null)
            {
                return BadRequest();
            }

            var user = new LunaIdentityUser
            {
                Email = model.Email,
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                IsActive = true
            };

            await UserManager.CreateAsync(user);

            var res = await UserManager.SendEmailConfirmation(user);
            if (!res)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Edit", new { id = user.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var user = await UserManager.FindByIdAsync(id.ToString());
            
            return View(new UserViewModel(user));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel model)
        {
            if (model?.Id == null)
            {
                return RedirectToAction("Index");
            }
            
            var user = await UserManager.FindByIdAsync(model.Id.ToString());
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;

            await UserManager.UpdateAsync(user);
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> ResetPassword(Guid id)
        {
            var user = await UserManager.FindByIdAsync(id.ToString());
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> ResendConfirmationEmail(Guid id)
        {
            var user = await UserManager.FindByIdAsync(id.ToString());
            
            var res = await UserManager.SendEmailConfirmation(user);
            if (!res)
            {
                // Message d'erreur d'envoi du mail
            }
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Disable(Guid id)
        {
            var user = await UserManager.FindByIdAsync(id.ToString());
            user.IsActive = false;
            
            await UserManager.UpdateAsync(user);
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Enable(Guid id)
        {
            var user = await UserManager.FindByIdAsync(id.ToString());
            user.IsActive = true;
            
            await UserManager.UpdateAsync(user);
            
            return RedirectToAction("Index");
        }
    }
}