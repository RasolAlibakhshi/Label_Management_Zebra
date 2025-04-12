using Application.Contracts.Label;
using Application.Execution.Label;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presention.Areas.Admin.Pages.Label
{
    public class InterwovenManagementModel : PageModel
    {
        
        private readonly ILabelApplication _LabelApplication;

        public InterwovenManagementModel(ILabelApplication labelApplication)
        {
            _LabelApplication = labelApplication;
        }
        public List<LabelViewModel> LabelsView { get; set; }
        public List<HallSelctList>  hallselectview { get; set; }
        public void OnGet(LabelSearchModel command)
        {
            LabelsView = _LabelApplication.Search(command);
            hallselectview = _LabelApplication.hallSelectList();
        }


        public IActionResult OnGetRemove(long id)
        {
            _LabelApplication.Remove(id);
            return RedirectToPage("/Label/InterwovenManagement");
        }

        public IActionResult OnGetRestore(long id)
        {
            _LabelApplication.Restore(id);
            return RedirectToPage("/Label/InterwovenManagement");
        }
    }
}
