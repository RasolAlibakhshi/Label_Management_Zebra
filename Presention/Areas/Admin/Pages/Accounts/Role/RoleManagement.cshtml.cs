using AccontManagement.Application.Account;
using AccountManagement.Application;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.Contract.Acconut;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presention.Areas.Admin.Pages.Accounts.Role
{
    public class RoleManagementModel : PageModel
    {
        private readonly IRoleApplication _roleApplication;

        public RoleManagementModel(IRoleApplication roleApplication)
        {
            _roleApplication = roleApplication;

        }

        public List<RoleViewModel> RoleView;
        public void OnGet()
        {
            RoleView = _roleApplication.List();
        }

        public IActionResult OnPost(CreateRole command)
        {
            _roleApplication.Create(command);
            TempData["ValiDation"] = "ثبت کاربر با موفقیت انجام شد.";
            return RedirectToPage("RoleManagement");
        }

        public IActionResult OnGetRemove(long id)
        {
            _roleApplication.Remove(id);
            TempData["ValiDation"] = "کاربر مورد نظر با موفقیت از دسترس خارج شد.";
            return RedirectToPage("RoleManagement");
        }

        public IActionResult OnGetRestore(long id)
        {
            _roleApplication.Restore(id);
            TempData["ValiDation"] = "کاربر مورد دسترسی دوباره گرفت.";
            return RedirectToPage("RoleManagement");
        }
    }
}
