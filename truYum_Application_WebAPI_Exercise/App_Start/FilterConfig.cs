using System.Web;
using System.Web.Mvc;

namespace truYum_Application_WebAPI_Exercise
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
