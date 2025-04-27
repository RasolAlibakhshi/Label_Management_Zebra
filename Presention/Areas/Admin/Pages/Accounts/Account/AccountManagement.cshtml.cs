using AccontManagement.Application.Account;
using AccountManagement.Contract.Acconut;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Presention.Areas.Admin.Pages.Accounts.Acoount
{
    public class AccountManagementModel : PageModel
    {
        private readonly IAccountApplicationcs _accountApplicationcs;

        public AccountManagementModel(IAccountApplicationcs accountApplicationcs)
        {
            _accountApplicationcs = accountApplicationcs;
        }

        public List<AccountViewModel> AccontView;
        public void OnGet(SearchModel command)
        {
            AccontView = _accountApplicationcs.Search(command);
        }

        public IActionResult OnGetRemove(long id)
        {
            TempData["ValiDation"] = _accountApplicationcs.Remove(id).Message;
            return RedirectToPage("AccountManagement");
        }
    }
}
