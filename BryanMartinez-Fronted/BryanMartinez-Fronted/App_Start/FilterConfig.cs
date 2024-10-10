using System.Web;
using System.Web.Mvc;

namespace BryanMartinez_Fronted
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
