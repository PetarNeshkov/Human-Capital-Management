using Microsoft.AspNetCore.Identity;

namespace HumanCapitalManagement.Web.Infrastructure
{
    public static class IdentityOptionsExtensions
    {
        public static IdentityOptions SetIdentityOptions(this IdentityOptions options)
        {
           
            options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ ";
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;

            return options;
        }


    }
}
