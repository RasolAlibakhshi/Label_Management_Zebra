using Application.Contracts.Hall;
using Application.Execution.Hall;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presention.Areas.Admin.Pages
{
    [Authorize]
    public class EditeHallModel : PageModel
    {
        private readonly IHallApplication _hallApplication;

        public EditeHallModel(IHallApplication hallApplication)
        {
            _hallApplication = hallApplication;
        }

        public EditHall HallProp;

        public void OnGet(long id)
        {
            HallProp = _hallApplication.GetDetails(id);
        }

        public IActionResult OnPost(EditHall command)
        {
            if (ModelState.IsValid)
            {
                _hallApplication.Edit(command);
            }
            return RedirectToPage("/Hall/HallManegment");
        }
    }
}
