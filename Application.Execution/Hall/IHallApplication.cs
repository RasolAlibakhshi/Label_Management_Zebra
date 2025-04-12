using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using Application.Contracts.Hall;

namespace Application.Execution.Hall
{
    public interface IHallApplication
    {
        OpreationResult Create(CreateHall command);
        OpreationResult Edit(EditHall command);
        EditHall GetDetails(long id);
        List<HallViewModel> Search(HallSearchModel command);
        void Remove(long id);
        void Restore(long id);
    }
}
