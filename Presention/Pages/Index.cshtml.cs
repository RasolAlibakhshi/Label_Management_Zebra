using Application.Contracts.Hall;
using Application.Execution.Hall;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presention.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHallApplication _hallApplication;

        public IndexModel(IHallApplication hallApplication)
        {
            _hallApplication = hallApplication;
        }
        public List<HallViewModel> HallView { get; set; }
        public void OnGet(HallSearchModel commnd)
        {
            HallView = _hallApplication.Search(commnd).Where(x=>x.IsRemove==false).ToList();
        }

    }
}
