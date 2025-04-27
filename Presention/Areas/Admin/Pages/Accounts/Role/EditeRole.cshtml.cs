using AccountManagement.Application.Contracts.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presention.Areas.Admin.Pages.Accounts.Role
{
    public class EditeRoleModel : PageModel
    {
        private readonly IRoleApplication _roleApplication;

        public EditeRoleModel(IRoleApplication roleApplication)
        {
            _roleApplication = roleApplication;
        }
        public EditRole data { get; set; }
        public void OnGet(long id)
        {
            data = _roleApplication.GetDetails(id);
        }

        public IActionResult OnPost(EditRole command)
        {
            
            TempData["ValiDation"] = _roleApplication.Edit(command).Message;
            return RedirectToPage("RoleManagement");
        }
    }
}
