using Application.Contracts.Hall;
using Application.Execution.Hall;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presention.Areas.Admin.Pages.Hall
{
    public class HallManegmentModel : PageModel
    {
        private readonly IHallApplication _HallApplication;

        public HallManegmentModel(IHallApplication hallApplication)
        {
            _HallApplication = hallApplication;
        }
        public List<HallViewModel> _HallViewModel { get; set; }
        public void OnGet(HallSearchModel Command)
        {
            _HallViewModel = _HallApplication.Search(Command);
        }

        public IActionResult OnPost(CreateHall command)
        {
            _HallApplication.Create(command);
            return RedirectToPage();
        }


        public IActionResult OnGetRemove(long id)
        {
            _HallApplication.Remove(id);
            return RedirectToPage();
        }

        public IActionResult OnGetRestore(long id)
        {
            _HallApplication.Restore(id);
            return RedirectToPage();
        }



    }
}
