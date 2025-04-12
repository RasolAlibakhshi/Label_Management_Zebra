using _0_Framework.Application;
using Application.Contracts.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts.Label;

namespace Application.Execution.Label
{
    public interface ILabelApplication
    {
        OpreationResult Create(CreateLabel command);
        OpreationResult Edit(EditLabel command);
        EditLabel GetDetails(long id);
        List<LabelViewModel> Search(LabelSearchModel command);
        List<HallSelctList> hallSelectList();
        List<MachineSelectList> machineSelectList(long id);
        void Remove(long id);
        void Restore(long id);
    }
}
