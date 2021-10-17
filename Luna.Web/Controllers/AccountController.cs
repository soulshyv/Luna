using System;
using System.Threading.Tasks;
using Autofac;
using Luna.Commons.Authentication;
using Luna.Mvc;
using Luna.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Luna.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        private LunaSignInManager _signInManager;
        private LunaSignInManager SignInManager => _signInManager ??= _scope.Resolve<LunaSignInManager>();
        
        private LunaUserManager _userManager;
        private LunaUserManager UserManager => _userManager ??= _scope.Resolve<LunaUserManager>();
        
        private ILogger<AccountController> _logger;
        private ILogger<AccountController> Logger => _logger ??= _scope.Resolve<ILogger<AccountController>>();
        
        public AccountController(ILifetimeScope scope) : base(scope)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var res = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if (!res.Succeeded)
            {
                return View();
            }
            
            if (Url.IsLocalUrl(model.ReturnUrl))
            {
                return Redirect(model.ReturnUrl);
            }
            
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public async  Task<IActionResult> ConfirmEmail(Guid id, string token)
        {
            var user = await UserManager.FindByIdAsync(id.ToString());

            if (await UserManager.HasPasswordAsync(user))
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            var vm = new AccountViewModel
            {
                Id = id,
                Token = token,
                Email = user.Email
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmEmail(AccountViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // Message d'erreur : Des informations saisies ne sont pas valides
                
                return View(model);
            }
            
            var user = await UserManager.FindByIdAsync(model.Id.ToString());

            var resEmailConfirmation = await UserManager.ConfirmEmailAsync(user, model.Token);
            if (!resEmailConfirmation.Succeeded)
            {
                // Message d'erreur : Une erreur est survenue lors de la confirmation de l'e-mail (resEmailConfirmation.Errors.FirstOrDefault()?.Description)
                
                return View(model);
            }

            var resPasswordAdded = await UserManager.AddPasswordAsync(user, model.Password);
            if (!resPasswordAdded.Succeeded)
            {
                // Message d'erreur : Une erreur est survenue lors de l'ajout du mot de passe (resPasswordAdded.Errors.FirstOrDefault()?.Description)
                
                return View(model);
            }
            
            // Message de succès : Votre compte a bien été activé et votre mot de passe a été défini
            
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}