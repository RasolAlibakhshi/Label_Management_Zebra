using Application.Contracts.LabelType;
using Application.Execution.LabelType;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presention.Areas.Admin.Pages.LabelType
{
    public class LabelTypeManagementModel : PageModel
    {
        private readonly ILabelTypeApplication _labelTypeApplication;

        public LabelTypeManagementModel(ILabelTypeApplication labelTypeApplication)
        {
            _labelTypeApplication = labelTypeApplication;
        }
        public List<LabelTypeViewModel> ValetTypeView { get; set; }
        public void OnGet(LabelTypeSerachModel command)
        {
            ValetTypeView = _labelTypeApplication.Search(command);
        }


        public IActionResult OnGetDownload(long id)
        {
            
            var data = _labelTypeApplication.GetDetails(id);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", data.LabelURL);
            string FileName = data.Name + ".prn";
            return PhysicalFile(filePath, "application/prn", FileName);
        }


        public IActionResult OnGetRemove(long id)
        {
            _labelTypeApplication.Remove(id);
            return RedirectToPage();
        }
        public IActionResult OnGetRestore(long id)
        {
            _labelTypeApplication.Restore(id);
            return RedirectToPage();
        }
    }
}
