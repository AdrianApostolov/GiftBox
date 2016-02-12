using System.Web.Mvc;

namespace GiftBox.Web.Areas.HomeAdministration
{
    public class HomeAdministrationAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "HomeAdministration";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "HomeAdministration_default",
                "HomeAdministration/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "GiftBox.Web.Areas.HomeAdministration.Controllers" }
            );
        }
    }
}