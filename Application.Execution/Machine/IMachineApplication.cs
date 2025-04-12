using _0_Framework.Application;
using Application.Contracts.Hall;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts.Machine;

namespace Application.Execution.Machine
{
    public interface IMachineApplication
    {
        OpreationResult Create(CreateMachine command);
        OpreationResult Edit(EditMachine command);
        EditMachine GetDetails(long id);
        List<MachineViewModel> Search(MachineSearchModel command);
        List<HalSelectListModel> hallListModels();
        void Remove(long id);
        void Restore(long id);
    }
}
