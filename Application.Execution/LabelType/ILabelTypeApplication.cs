using _0_Framework.Application;
using Application.Contracts.Label;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts.LabelType;

namespace Application.Execution.LabelType
{
    public interface ILabelTypeApplication
    {
        OpreationResult Create(CreateLabelType command);
        OpreationResult Edit(EditLabelType command);
        Domain.LabelType GetDetails(long id);
        List<LabelTypeViewModel> Search(LabelTypeSerachModel command);
        void Remove(long id);
        void Restore(long id);
    }
}
