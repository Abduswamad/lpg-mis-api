using System.Security.Claims;

namespace Gas.Utils
{
    public static class ClaimsIdentityExtension
    {
        public static bool HasRole(this ClaimsPrincipal principal, string roleName)
        {
            var claim = principal.Claims.Where(t => t.Type == "role" && t.Value == roleName)
                                 .Select(d => new { Value = d.Value, Key = d.Type })
                                 .FirstOrDefault();

            return claim != null ? true : false;
        }

        public static string GetStaffId(this ClaimsPrincipal principal)
        {
            var claim = principal.Claims.FirstOrDefault(x => x.Type == "Staff_id")?.Value;
            return claim != null ? claim : "";
        }

        public static string GetSuperDealerId(this ClaimsPrincipal principal)
        {
            var claim = principal.Claims.FirstOrDefault(x => x.Type == "Super_dealer_id")?.Value;
            return claim != null ? claim : "";
        }

        public static string GetUserName(this ClaimsPrincipal principal)
        {
            var claim = principal.FindFirst("Username")?.Value;
            return claim != null ? claim : "";
        }

    }

}
