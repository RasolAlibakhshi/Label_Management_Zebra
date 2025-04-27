using _0_Framework.Application;
using AccontManagement.Application.Account;
using AccountManagement.Contract.Acconut;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presention.Pages
{
    public class LogInAdminModel : PageModel
    {
        private readonly IAccountApplicationcs _accountApplicationcs;
        private readonly IAuthHelper _authHelper;

        public LogInAdminModel(IAccountApplicationcs accountApplicationcs, IAuthHelper authHelper)
        {
            _accountApplicationcs = accountApplicationcs;
            _authHelper = authHelper;
        }
        public IActionResult OnGet()
        {
            if (_authHelper.IsAuthenticated())
            {
                return RedirectToPage("Menu",new {area="Admin"});
            }
            return Page();
        }

        public IActionResult OnPost(Login command)
        {
            var data = _accountApplicationcs.Login(command);
            if (data.Succedded)
            {
                return RedirectToPage("Menu", new { area = "Admin" });
            }
            TempData["ValiDation"]= data.Message;
            return RedirectToPage("LogInAdmin");

        }
        public IActionResult OnGetLogout()
        {
            _authHelper.SignOut();
            return RedirectToPage("LogInAdmin");
        }
    }
}
