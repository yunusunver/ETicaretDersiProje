using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaretDersiProje.Eticaret.MvcWebUI.Filters
{
    public class Auth: ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {

            if (context.HttpContext.Session["email"] == null)
            {
                context.Result = new RedirectResult("/Home/Index");
                return;
            }
        }
    }
}