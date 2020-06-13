using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using VK.PersonFinder.WebUI.Models;
using VK.PersonFinder.WebUI.Service;

namespace VK.PersonFinder.WebUI.Controllers
{
    public class IdentityController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly SignInManager<IdentityUser> _signinManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IdentityController(UserManager<IdentityUser> userManager, IEmailSender emailSender, SignInManager<IdentityUser> signinManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _emailSender = emailSender;
            _signinManager = signinManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!await _roleManager.RoleExistsAsync(model.Role))
                {
                    var role = new IdentityRole { Name = model.Role };
                    var roleResult = await _roleManager.CreateAsync(role);
                    if (roleResult.Succeeded)
                    {
                        var errors = roleResult.Errors.Select(s => s.Description);
                        ModelState.AddModelError("Role", string.Join(",", errors));
                        return View(model);
                    }
                }

                if ((await _userManager.FindByEmailAsync(model.Email)) == null)
                {
                    IdentityUser newUser = new IdentityUser();
                    newUser.Email = model.Email;
                    newUser.UserName = model.Email;
                    //newUser.PasswordHash = model.Password;

                    IdentityResult result = await _userManager.CreateAsync(newUser, model.Password);
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);

                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(newUser, model.Role);

                        string conformationLink = Url.ActionLink(
                            "ConfirmEmail", "Identity", new { userId = newUser.Id, @token = token });

                        await _emailSender.SendEmailAsync("kramarvladimir@gmail.com", newUser.Email, "Subject", conformationLink);

                        return RedirectToAction("Signin");
                    }

                    ModelState.AddModelError("SignUp", string.Join("", result.Errors.Select(x => x.Description)));
                    return View(model);
                }
            }

            return View(model);
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return RedirectToAction("Signin");
            }

            return new NotFoundResult();
        }

        [HttpGet]
        public async Task<IActionResult> SignUp()
        {
            SignUpViewModel model = new SignUpViewModel() { Role = "Member"};

            return View(model);
        }

        public IActionResult SignIn()
        {
            return View(new SignInViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signinManager.PasswordSignInAsync(model.UserName, model.Password, model.RemeberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Login", "Cannot login.");
                }
            }

            return View(model);
        }

        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }

        public async Task<IActionResult> SignOut()
        {
            await _signinManager.SignOutAsync();
            return RedirectToAction("Signin");
        }

        [HttpPost]
        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            var properties = _signinManager.ConfigureExternalAuthenticationProperties(provider, returnUrl);
            var callBackUrl = Url.Action("ExternalLoginCallback");
            properties.RedirectUri = callBackUrl;
            return Challenge(properties, provider);
        }

        public async Task<IActionResult> ExternalLoginCallback()
        {
            var info = await _signinManager.GetExternalLoginInfoAsync();
            var emailClaim = info.Principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
            var user = new IdentityUser { Email = emailClaim.Value, UserName = emailClaim.Value };
            await _userManager.CreateAsync(user);
            await _userManager.AddLoginAsync(user, info);
            await _signinManager.SignInAsync(user, false);

            return RedirectToAction("Search", "PersonFinder");
        }
    }
}
