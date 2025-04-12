using Application.Contracts.Hall;
using Application.Contracts.Machine;
using Application.Execution.Hall;
using Application.Execution.Machine;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presention.Pages
{
    public class SelectMachineModel : PageModel
    {
        private readonly IHallApplication _hallApplication;
        private readonly IMachineApplication _machineApplication;

        public SelectMachineModel(IHallApplication hallApplication, IMachineApplication machineApplication)
        {
            _hallApplication = hallApplication;
            _machineApplication = machineApplication;
        }
        public List<HallViewModel> HallView { get; set; }
        public List<MachineViewModel> MachineView { get; set; }
        public long ID { set; get; }

        public void OnGet(int id)
        {
            HallView = _hallApplication.Search(new HallSearchModel()).Where(x=>x.IsRemove==false).ToList();
            MachineView = _machineApplication.Search(new MachineSearchModel
            {
                HallID = id
            }).Where(x=>x.IsDeleted==false).ToList();
            ID = id;
        }
    }
}
