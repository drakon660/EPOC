using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Ecm.Core;
using Ecm.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecm.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthorizationManager _authorizationManager;
        public AccountController(AuthorizationManager authorizationManager)
        {
            _authorizationManager = authorizationManager;
        }

        public IActionResult SignInWithGoogle()
        { 
            string callbackUrl = Url.Action(nameof(HandleExternalLogin));

            AuthenticationProperties props = new AuthenticationProperties {
                RedirectUri = callbackUrl,
                Items = {
                            { "scheme", "Google" },
                            { "returnUrl", nameof(HandleExternalLogin) }
                        }
            };

            return Challenge(props, "Google");
        }

        public async Task<IActionResult> HandleExternalLogin()
        {
            AuthenticateResult result = await HttpContext.AuthenticateAsync(IdentityConstants.ExternalScheme);
            if (result?.Succeeded != true)
            {
                throw new Exception("External authentication error");
            }

            ClaimsPrincipal externalUser = result.Principal;

            if (externalUser == null)
            {
                throw new Exception("External authentication error");
            }

            string email = externalUser.FindFirst(ClaimTypes.Email).Value;

            if (string.IsNullOrEmpty(email))
            {
                return Redirect("~/login/errorprovider");
            }

            bool isAuthorized = _authorizationManager.IsUserOrDomainAuthorized(email);
            if (!isAuthorized)
                return Redirect("~/login/notauthorized");

            if (isAuthorized)
            {
                try
                {
                    ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                    identity.AddClaim(new Claim(ClaimTypes.Name, email));
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), new AuthenticationProperties
                    {
                        IsPersistent = true
                    });
                    await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
                }
                catch
                {
                    return Redirect("~/login/error");
                }
            }

            return Redirect("~/");
        }

        public IActionResult IsUserAuthenticated()
        {
            IIdentity identity = HttpContext.User?.Identity;
            return Ok(UserModel.CreateNew(identity != null ? identity.Name : "", identity != null ? identity.IsAuthenticated : false));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("~/");
        }
    }
}