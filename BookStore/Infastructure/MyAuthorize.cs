using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookStore.Infastructure
{
 
    public class MyAuthorizeAttribute : ActionFilterAttribute

    {     



        public override void OnActionExecuting(ActionExecutingContext filterContext)

        {

            var myid = filterContext.RouteData.Values["id"] as string;

            if (myid != null)

            {             

                filterContext.ActionParameters["id"] = Convert.ToInt32(ApiSecurity.DecryptString(myid));

            }

            base.OnActionExecuting(filterContext);

        }

    }
}