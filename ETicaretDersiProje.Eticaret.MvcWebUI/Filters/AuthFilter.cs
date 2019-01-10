using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaretDersiProje.Eticaret.Business.Abstract;

namespace ETicaretDersiProje.Eticaret.MvcWebUI.Filters
{
    public class AuthFilter:ActionFilterAttribute
    {
       

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            
            if (context.HttpContext.Session["email"]==null || (string)context.HttpContext.Session["role"]!="Admin")
            {
                context.Result=new RedirectResult("/Home/Index");
                return;
            }
        }
    }
}