using System;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Luna.Commons.Authentication;
using Luna.Commons.Models;
using Luna.Commons.Models.Identity;
using Luna.Mvc;
using Luna.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Luna.Areas.Admin.Controllers
{
    public class UserController : LunaAdminController
    {
        private LunaUserManager _userManager;
        private LunaUserManager UserManager => _userManager ??= Scope.Resolve<LunaUserManager>();
        
        private LunaRoleManager _roleManager;
        private LunaRoleManager RoleManager => _roleManager ??= Scope.Resolve<LunaRoleManager>();
        
        public UserController(ILifetimeScope scope) : base(scope)
        {
        }

        public async Task<IActionResult> Index()
        {
            var users = await UserManager.Users.ToArrayAsync();
            
            return View(users);
        }
        
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var vm = new UserViewModel();

            var allRoles = await RoleManager.Roles.ToArrayAsync();
            vm.AllRoles = allRoles;
            
            return View(vm);
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

            if (model.Roles?.Any() == true)
            {
                await UserManager.AddToRolesAsync(user, model.Roles);
            }

            var res = await UserManager.SendEmailConfirmation(user);
            if (!res)
            {
                // Message d'erreur
                return RedirectToAction("Index");
            }

            return RedirectToAction("Edit", new { id = user.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var user = await UserManager.FindByIdAsync(id.ToString());
            
            var vm = new UserViewModel(user);
            
            var role = (await UserManager.GetRolesAsync(user));
            vm.Roles = role.ToList();

            var allRoles = await RoleManager.Roles.ToArrayAsync();
            vm.AllRoles = allRoles;
            
            return View(vm);
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

            var currentRoles = await UserManager.GetRolesAsync(user);
            await UserManager.RemoveFromRolesAsync(user, currentRoles);

            if (model.Roles?.Any() == true)
            {
                await UserManager.AddToRolesAsync(user, model.Roles);
            }
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRolesForSelect()
        {
            var races = await RoleManager.Roles.ToArrayAsync();
            
            return Ok(races.Select(_ => new SelectListItem(_.Name, _.Id.ToString())));
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