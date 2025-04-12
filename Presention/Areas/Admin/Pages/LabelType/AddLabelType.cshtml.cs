using Application.Contracts.Hall;
using Application.Contracts.LabelType;
using Application.Execution.Hall;
using Application.Execution.LabelType;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presention.Areas.Admin.Pages.LabelType
{
    public class AddLabelTypeModel : PageModel
    {
        private readonly ILabelTypeApplication _labelTypeApplication;
        private readonly IHallApplication _hallApplication;

        public AddLabelTypeModel(ILabelTypeApplication labelTypeApplication, IHallApplication hallApplication)
        {
            _labelTypeApplication = labelTypeApplication;
            _hallApplication = hallApplication;
        }


        public List<HallViewModel> HallSelectview { get; set; }
        public void OnGet()
        {
            HallSelectview = _hallApplication.Search(new HallSearchModel());
        }

        public IActionResult OnPost(CreateLabelType Command)
        {
            _labelTypeApplication.Create(Command);
            return RedirectToPage("/LabelType/AddLabelType");
        }
    }
}
