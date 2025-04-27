using AccontManagement.Application.Account;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.Contract.Acconut;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presention.Areas.Admin.Pages.Accounts.Acoount
{
    public class EditAccountModel : PageModel
    {
        private readonly IRoleApplication _roleApplication;
        private readonly IAccountApplicationcs _accountApplicationcs;

        public EditAccountModel(IRoleApplication roleApplication, IAccountApplicationcs accountApplicationcs)
        {
            _roleApplication = roleApplication;
            _accountApplicationcs = accountApplicationcs;
        }

        public EditAccount data { set; get; }
        public List<RoleViewModel> selectListRole { set; get; }
        public void OnGet(long id)
        {
            selectListRole = _roleApplication.List();
            data = _accountApplicationcs.GetDetails(id);
        }

        public IActionResult OnPost(EditAccount command)
        {
            
            
            TempData["ValiDation"] = _accountApplicationcs.Edit(command).Message;
            return RedirectToPage("AccountManagement");
        }
    }
}
