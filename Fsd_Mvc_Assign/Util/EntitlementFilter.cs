using System.Web.Mvc;
using System.Web.Mvc.Filters;
namespace Fsd_Mvc_Assign.Util
{
    public class EntitlementFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (filterContext.RequestContext.HttpContext.Session["userid"] == null)
                filterContext.HttpContext.Response.Redirect("/Profile/Index");
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
        }
    }
}