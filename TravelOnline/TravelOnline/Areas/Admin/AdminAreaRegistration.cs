using System.Web.Mvc;

namespace TravelOnline.Areas.Admin
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
            name: "Admin_Default",
            url: "Admin/{controller}/{action}/{id}",
            defaults: new
            {
                area = "Admin",
                controller = "Home",
                action = "Index",
                id = UrlParameter.Optional
            });

        }
    }
}
