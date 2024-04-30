using System.Security.Claims;

namespace Gas.Utils
{
    public static class ClaimsIdentityExtension
    {
        public static bool HasRole(this ClaimsPrincipal principal, string roleName)
        {
            var claim = principal.Claims.Where(t => t.Type == "role" && t.Value == roleName)
                                 .Select(d => new { d.Value, Key = d.Type })
                                 .FirstOrDefault();

            return claim != null;
        }

        public static string GetStaffId(this ClaimsPrincipal principal)
        {
            var claim = principal.Claims.FirstOrDefault(x => x.Type == "Staff_id")?.Value;
            return claim ?? "";
        }

        public static int GetSuperDealerId(this ClaimsPrincipal principal)
        {
            var claim = principal.Claims.FirstOrDefault(x => x.Type == "Super_dealer_id")?.Value;
            return int.Parse(claim ?? "0") ;
        }

        public static string GetSuperDealerName(this ClaimsPrincipal principal)
        {
            var claim = principal.Claims.FirstOrDefault(x => x.Type == "Super_dealer_name")?.Value;
            return claim ?? "";
        }
        
        public static string GetUserName(this ClaimsPrincipal principal)
        {
            var claim = principal.FindFirst("Username")?.Value;
            return claim ?? "";
        }

        public static string GetClaimValue(this ClaimsPrincipal principal,string ClaimName)
        {
            var claim = principal.Claims.FirstOrDefault(x => x.Type == ClaimName)?.Value;
            return claim ?? "";
        }

    }

}
