using System;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Luna.Commons.Authentication;
using Luna.Commons.Models;
using Luna.Commons.Models.Identity;
using Luna.Mvc;
using Luna.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Luna.Controllers
{
    public class AccountController : LunaBaseController
    {
        private LunaSignInManager _signInManager;
        private LunaSignInManager SignInManager => _signInManager ??= Scope.Resolve<LunaSignInManager>();
        
        private LunaUserManager _userManager;
        private LunaUserManager UserManager => _userManager ??= Scope.Resolve<LunaUserManager>();
        
        private ILogger<AccountController> _logger;
        private ILogger<AccountController> Logger => _logger ??= Scope.Resolve<ILogger<AccountController>>();
        
        public AccountController(ILifetimeScope scope) : base(scope)
        {
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            
            return View();
        }

        [AllowAnonymous]
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
        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [AllowAnonymous]
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

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ConfirmEmail(AccountViewModel model)
        {
            if (!ModelState.IsValid)
            {
                Logger.LogError("Des informations saisies ne sont pas valides");
                
                return View(model);
            }
            
            var user = await UserManager.FindByIdAsync(model.Id.ToString());

            var resEmailConfirmation = await UserManager.ConfirmEmailAsync(user, model.Token);
            if (!resEmailConfirmation.Succeeded)
            {
                // Message d'erreur : Une erreur est survenue lors de la confirmation de l'e-mail
                Logger.LogError("Une erreur est survenue lors de la confirmation de l'e-mail : {Message}", new { Message = resEmailConfirmation.Errors.FirstOrDefault()?.Description});
                
                return View(model);
            }

            var resPasswordAdded = await UserManager.AddPasswordAsync(user, model.Password);
            if (!resPasswordAdded.Succeeded)
            {
                // Message d'erreur : Une erreur est survenue lors de l'ajout du mot de passe
                Logger.LogError("Une erreur est survenue lors de l'ajout du mot de passe : {Message}", resPasswordAdded.Errors.FirstOrDefault()?.Description);
                
                return View(model);
            }
            
            // Message de succès : Votre compte a bien été activé et votre mot de passe a été défini
            
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Registration()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                Logger.LogInformation("Modèle invalide");
            
                return View(model);
            }

            try
            {
                var checkUser = await UserManager.FindByEmailAsync(model.Email);

                if (checkUser != null)
                {
                    Logger.LogWarning("Utilisateur existant");
                    
                    // Message de succès : Un mail de confirmation a été envoyé à l'adresse mail si celle-ci existe
                
                    return View();
                }
            }
            catch (Exception e)
            {
                Logger.LogError(e, e.Message);
            }

            var user = new LunaIdentityUser
            {
                Email = model.Email,
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                IsActive = true
            };

            try
            {
                await UserManager.CreateAsync(user);

                await UserManager.AddToRoleAsync(user, LunaApplicationRole.Joueur);
            }
            catch (Exception e)
            {
                Logger.LogError(e, e.Message);
            }

            var res = await UserManager.SendEmailConfirmation(user);
            if (!res)
            {
                // Message d'erreur
                Logger.LogError("Erreur à l'envoi du mail de confirmation");

                return View();
            }

            return RedirectToAction("Login");
        }
    }
}