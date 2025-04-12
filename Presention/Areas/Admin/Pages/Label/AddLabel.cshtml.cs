using Application.Contracts.Label;
using Application.Execution.Label;
using Application.Execution.Machine;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presention.Areas.Admin.Pages.Label
{
    public class AddLabelModel : PageModel
    {
        private readonly ILabelApplication _labelApplication;
        

        public AddLabelModel(ILabelApplication labelApplication)
        {
            _labelApplication = labelApplication;
    
        }
        public List<MachineSelectList> MachineSelectView { set; get; }
        public void OnGet(long id)
        {
            MachineSelectView = _labelApplication.machineSelectList(id);
        }

        public IActionResult OnPost(CreateLabel command)
        {
            
            TempData["Validation"]=_labelApplication.Create(command).Message;
            return RedirectToPage("/Label/InterwovenManagement");

        }
    }
}
