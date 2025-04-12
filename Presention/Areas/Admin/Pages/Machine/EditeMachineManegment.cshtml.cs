using Application.Contracts.Machine;
using Application.Execution.Machine;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presention.Areas.Admin.Pages.Machine
{
    public class EditeMachineManegmentModel : PageModel
    {
        private readonly IMachineApplication _MachineApplication;

        public EditeMachineManegmentModel(IMachineApplication machineApplication)
        {
            _MachineApplication = machineApplication;
        }
        public List<HalSelectListModel> HalSelectListModel { get; set; }
        public EditMachine EditMachineViewModel { get; set; }
        public void OnGet(int id)
        {
            EditMachineViewModel = _MachineApplication.GetDetails(id);
            HalSelectListModel = _MachineApplication.hallListModels();
        }

        public IActionResult OnPost(EditMachine command)
        {

            _MachineApplication.Edit(command);
            return RedirectToPage("/Machine/MachineManegment");
        }
    }
}
