using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ETicaretDersiProje.Core.CrossCuttingConcerns.Validations.FluentValidation;
using ETicaretDersiProje.Core.Utilities.Mvc.Infrastructure;
using ETicaretDersiProje.Eticaret.Business.DependencyResolvers.Ninject;
using FluentValidation.Mvc;


namespace ETicaretDersiProje.Eticaret.MvcWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FluentValidationModelValidatorProvider.Configure(provider =>
                {
                    provider.ValidatorFactory = new NinjectValidationFactory(new ValidationModule());
                });
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new BusinessModule()));
        }
    }
}
