using AccontManagement.Application.Account;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.Contract.Acconut;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presention.Areas.Admin.Pages.Accounts.Acoount
{
    public class AddAccountModel : PageModel
    {
        private readonly IRoleApplication _roleApplication;
        private readonly IAccountApplicationcs _accountApplicationcs;

        public AddAccountModel(IRoleApplication roleApplication, IAccountApplicationcs accountApplicationcs)
        {
            _roleApplication = roleApplication;
            _accountApplicationcs = accountApplicationcs;
        }

        public List<RoleViewModel> selectListRole { set; get; }
        public void OnGet()
        {
            selectListRole = _roleApplication.List();
        }

        public IActionResult OnPost(CreateAccount command)
        {
            TempData["ValiDation"] = _accountApplicationcs.Create(command).Message;
            return RedirectToPage("AccountManagement");
        }
    }
}
