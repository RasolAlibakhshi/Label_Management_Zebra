using Application.Contracts.Hall;
using Application.Contracts.LabelType;
using Application.Execution.Hall;
using Application.Execution.LabelType;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presention.Areas.Admin.Pages.LabelType
{
    public class EditeLabelTypeModel : PageModel
    {
        private readonly ILabelTypeApplication _labelTypeApplication;
        private readonly IHallApplication _hallApplication;

        public EditeLabelTypeModel(ILabelTypeApplication labelTypeApplication, IHallApplication hallApplication)
        {
            _labelTypeApplication = labelTypeApplication;
            _hallApplication = hallApplication;
        }

        public Domain.LabelType LabelTypeView { get; set; }
        public List<HallViewModel> HallSelectview { get; set; }
        public void OnGet(long id)
        {
            LabelTypeView = _labelTypeApplication.GetDetails(id);
            HallSelectview = _hallApplication.Search(new HallSearchModel());
        }

        public IActionResult OnPost(EditLabelType command)
        {
            _labelTypeApplication.Edit(command);
            return RedirectToPage("/LabelType/LabelTypeManagement");
        }
    }
}
