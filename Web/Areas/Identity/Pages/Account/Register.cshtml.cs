using HumanCapitalManagement.Data.Models;
using HumanCapitalManagement.Web.Areas.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using static HumanCapitalManagement.Common.ErrorMessages.Register;

namespace HumanCapitalManagement.Web.Areas.Identity.Pages.Account
{

    public class RegisterModel(SignInManager<User> signInManager, UserManager<User> userManager) 
        : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public RegisterInputModel Input { get; set; }
        
        public string ReturnUrl { get; set; }


        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            if (User.Identity is { IsAuthenticated: true })
            {
                return Redirect("/");
            }
            ReturnUrl = returnUrl;
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Email = Input.Email,
                    FullName = Input.FullName,
                    UserName = Input.FullName
                };
                
                var isUsernameUsed = await userManager.FindByNameAsync(Input.FullName);

                if (isUsernameUsed != null)
                {
                    ModelState.AddModelError(nameof(Input.FullName), ExistingUsername);
                    
                    return Page();
                }

                var isEmailUsed = await userManager.FindByEmailAsync(Input.Email);
                if (isEmailUsed != null)
                {
                    ModelState.AddModelError(nameof(Input.Email), ExistingEmail);
                    
                    return Page();
                }

                var result = await userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    if (userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email });
                    }

                    await signInManager.SignInAsync(user, isPersistent: false);
                    
                    return LocalRedirect(returnUrl);
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }
    }
}