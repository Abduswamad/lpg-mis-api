using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Gas.Common
{
    public class RestrictAttribute : ActionFilterAttribute
    {
        public RestrictAttribute()
        {
        }
        public string AllowVerbs { get; set; }
        public string DenyVerbs { get; set; }
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            //get the verb
            var verb = actionContext.HttpContext.Request.Method;
            if (AllowVerbs != verb)
                actionContext.Result = new StatusCodeResult(405);
        }
    }
}
