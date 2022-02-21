using System.Web.Mvc;

namespace Coderin.UI.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name: "Admin_default",
                url: "Admin/{controller}/{action}/{id}/{id2}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional,id2=UrlParameter.Optional },
                namespaces: new[] {"Coderin.UI.Areas.Admin.Controllers" }

            );
        }
    }
}