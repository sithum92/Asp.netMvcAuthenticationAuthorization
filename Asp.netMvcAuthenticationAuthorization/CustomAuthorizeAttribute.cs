using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp.netMvcAuthenticationAuthorization
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {

        public string ViewName { get; set; }


        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            IsUserAuthorized(filterContext);
        }

        void IsUserAuthorized(AuthorizationContext filterContext)
        {
            //user is authorized
            if (filterContext.Result == null)
                return;
           if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            { 
            ViewDataDictionary dictionary = new ViewDataDictionary();
                dictionary.Add("Message","You Are Not Autherized!");
                var result = new ViewResult() { ViewName = this.ViewName, ViewData = dictionary };
                filterContext.Result = result;
            }
        }

    }
}