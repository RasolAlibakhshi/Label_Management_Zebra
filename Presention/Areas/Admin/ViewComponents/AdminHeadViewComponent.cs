using Microsoft.AspNetCore.Mvc;

namespace Presention.Areas.Admin.ViewComponents
{
    public class AdminHeadViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
