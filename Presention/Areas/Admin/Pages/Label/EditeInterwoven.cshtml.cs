using Application.Contracts.Label;
using Application.Execution.Hall;
using Application.Execution.Label;
using Application.Execution.Machine;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presention.Areas.Admin.Pages.Label
{
    public class EditeInterwovenModel : PageModel
    {
        private readonly ILabelApplication _labelApplication;
        private readonly IMachineApplication _machineApplication;
        private readonly IHallApplication _hallApplication;

        public EditeInterwovenModel(ILabelApplication labelApplication, IMachineApplication machineApplication, IHallApplication hallApplication)
        {
            _labelApplication = labelApplication;
            _machineApplication = machineApplication;
            _hallApplication = hallApplication;
        }
        public List<MachineSelectList> MachineSelectView { set; get; }
        public EditLabel DetailView { set; get; }
        public void OnGet(long id)
        {
            DetailView = _labelApplication.GetDetails(id);
            MachineSelectView = _labelApplication.machineSelectList(_machineApplication.GetDetails(DetailView.MachineID).HallID);
        }

        public IActionResult OnPost(EditLabel command)
        {
            _labelApplication.Edit(command);
            return RedirectToPage("/Label/InterwovenManagement");
        }
    }
}
