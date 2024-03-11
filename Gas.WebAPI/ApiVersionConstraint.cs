using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Gas.WebAPI
{

    public class ApiVersionConstraint : IRouteConstraint
    {
        private readonly int _allowedVersion;

        public ApiVersionConstraint(int allowedVersion)
        {
            _allowedVersion = allowedVersion;
        }

        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values.TryGetValue(routeKey, out object routeValue) && routeValue != null)
            {
                if (int.TryParse(routeValue.ToString(), out int version))
                {
                    return version == _allowedVersion;
                }
            }

            return false;
        }
    }

}

