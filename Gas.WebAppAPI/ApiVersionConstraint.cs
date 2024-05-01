namespace Gas.WebAppAPI
{
    public class ApiVersionConstraint(int allowedVersion) : IRouteConstraint
    {
        private readonly int _allowedVersion = allowedVersion;

        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (httpContext != null && values.TryGetValue(routeKey, out object? routeValue) && routeValue != null)
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

