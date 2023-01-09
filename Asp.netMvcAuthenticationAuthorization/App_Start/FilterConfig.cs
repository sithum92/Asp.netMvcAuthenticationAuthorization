using System.ComponentModel;
using System.Web;
using System.Web.Mvc;

namespace Asp.netMvcAuthenticationAuthorization
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            //Add Global authorized attribute for all Controllers
            //Custom Code Snippet By Sithum
            filters.Add(new AuthorizeAttribute());

        }
    }
}
