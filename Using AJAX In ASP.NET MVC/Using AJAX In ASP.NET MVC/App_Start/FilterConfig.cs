using System.Web;
using System.Web.Mvc;

namespace Using_AJAX_In_ASP.NET_MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
