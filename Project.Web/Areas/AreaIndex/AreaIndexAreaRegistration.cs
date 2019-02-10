using System.Web.Mvc;

namespace Project.Web.Areas.AreaIndex
{
    public class AreaIndexAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AreaIndex";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AreaIndex_default",
                "AreaIndex/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }

   }
}