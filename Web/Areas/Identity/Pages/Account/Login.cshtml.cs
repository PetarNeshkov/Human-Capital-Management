using HumanCapitalManagement.Data.Models;
using HumanCapitalManagement.Web.Areas.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using static HumanCapitalManagement.Common.ErrorMessages.Login;

namespace HumanCapitalManagement.Web.Areas.Identity.Pages.Account
{

    public class LoginModel(
        SignInManager<User> signInManager,
        UserManager<User> userManager,
        ILogger<LoginModel> logger)
        : PageModel
    {
        [BindProperty]
        public LoginInputModel Input { get; set; }
        
        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            if (User.Identity is { IsAuthenticated: false })
            {
                if (!string.IsNullOrEmpty(ErrorMessage))
                {
                    ModelState.AddModelError(string.Empty, ErrorMessage);
                }

                returnUrl ??= Url.Content("~/");

                await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
                
                ReturnUrl = returnUrl;
                
                return Page();
            }

            return Redirect("/");
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var result = await signInManager
                    .PasswordSignInAsync(Input.Username, Input.Password, Input.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    logger.LogInformation(UserAlreadyLoggedIn);
                    return LocalRedirect(returnUrl);
                }

                if (result.IsLockedOut)
                {
                    logger.LogWarning(UserLockedOut);
                    
                    return RedirectToPage("./Lockout");
                }

                ModelState.AddModelError(string.Empty, InvalidCredentials);
            }

            return Page();
        }
    }
}