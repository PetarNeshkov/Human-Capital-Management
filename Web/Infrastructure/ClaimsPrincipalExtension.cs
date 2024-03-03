using System.Security.Claims;

using static HumanCapitalManagement.Common.GlobalConstants.Administrator;

namespace HumanCapitalManagement.Web.Infrastructure;

public static class ClaimsPrincipalExtensions
{
    public static bool IsAdministrator(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.IsInRole(AdministratorRoleName);
}