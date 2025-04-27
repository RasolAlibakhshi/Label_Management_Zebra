using _0_Framework.Application;
using Application.Contracts.Hall;
using Application.Execution.Hall;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presention.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHallApplication _hallApplication;
        private readonly IAuthHelper _authHelper;

        public IndexModel(IHallApplication hallApplication, IAuthHelper authHelper)
        {
            _hallApplication = hallApplication;
            _authHelper = authHelper;
        }
        public List<HallViewModel> HallView { get; set; }
        public void OnGet(HallSearchModel commnd)
        {
            HallView = _hallApplication.Search(commnd).Where(x=>x.IsRemove==false).ToList();
        }

        public IActionResult OnGetLogout()
        {
            _authHelper.SignOut();
            return RedirectToPage("Index");
        }

    }
}
