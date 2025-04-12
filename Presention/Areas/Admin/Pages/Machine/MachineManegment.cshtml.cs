using Application.Contracts.Hall;
using Application.Contracts.Machine;
using Application.Execution.Hall;
using Application.Execution.Machine;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presention.Areas.Admin.Pages.Machine
{
    public class MachineManegmentModel : PageModel
    {

       
        private readonly IMachineApplication _MachineApplication;

        public List<HalSelectListModel> HalSelectListModel { get; set; }
        public MachineManegmentModel(IMachineApplication machineApplication)
        {
          
            _MachineApplication = machineApplication;
            HalSelectListModel = _MachineApplication.hallListModels();
        }

        public List<MachineViewModel> MachineView { set; get; }
        public void OnGet(MachineSearchModel command)
        {
            MachineView = _MachineApplication.Search(command);
        }

        public IActionResult OnPost(CreateMachine command)
        {
            _MachineApplication.Create(command);
            return RedirectToPage("/Machine/MachineManegment");
        }



        public IActionResult OnGetRemove(int id)
        {
            _MachineApplication.Remove(id);
            return RedirectToPage("MachineManegment");
        }


        public IActionResult OnGetRestore(int id)
        {
            _MachineApplication.Restore(id);
            return RedirectToPage("MachineManegment");
        }
    }
}
