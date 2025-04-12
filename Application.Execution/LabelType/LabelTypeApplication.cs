using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using Application.Contracts.Label;
using Application.Contracts.LabelType;
using Infrastructure.DTO;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Execution.LabelType
{
    public class LabelTypeApplication: ILabelTypeApplication
    {
        private readonly IRepository<Domain.LabelType> _LabelTypeReposytory;
        private readonly IRepository<Domain.Hall> _hallReposytory;
        private readonly IFileUploder _FileUploder;

        public LabelTypeApplication(IRepository<Domain.LabelType> labelTypeReposytory, IRepository<Domain.Hall> hallReposytory, IFileUploder fileUploder)
        {
            _LabelTypeReposytory = labelTypeReposytory;
            _hallReposytory = hallReposytory;
            _FileUploder = fileUploder;
        }
        public OpreationResult Create(CreateLabelType command)
        {
            var operation = new OpreationResult();
            if (command==null)
            {
                return operation.Failed(ApplicationMessages.InputNull);
            }

            if (_LabelTypeReposytory.Exist(x=>x.Name==command.Name))
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }

            _LabelTypeReposytory.Create(new Domain.LabelType(command.HallID, command.Name, command.Description,
                _FileUploder.Upload(command.LabelURL, "PRN")));
            _LabelTypeReposytory.SaveChanges();
            return operation.Success();
        }

        public OpreationResult Edit(EditLabelType command)
        {
            var operation = new OpreationResult();
            if (command==null)
            {
                return operation.Failed(ApplicationMessages.InputNull);
            }

            if (_LabelTypeReposytory.Exist(x => x.Name==command.Name &&x.ID!=command.ID))
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }

            _LabelTypeReposytory.GetBy(x=>x.ID==command.ID).Edit(command.HallID, command.Name, command.Description,
                _FileUploder.Upload(command.LabelURL, "PRN"));
            _LabelTypeReposytory.SaveChanges();
            return operation.Success();
        }

        public Domain.LabelType GetDetails(long id)
        {
            return _LabelTypeReposytory.GetBy(x => x.ID == id);
        }

        public void Remove(long id)
        {
            _LabelTypeReposytory.GetBy(x => x.ID == id).Remove();
            _LabelTypeReposytory.SaveChanges();
        }

        public void Restore(long id)
        {
            _LabelTypeReposytory.GetBy(x => x.ID == id).Restore();
            _LabelTypeReposytory.SaveChanges();
        }

        public List<LabelTypeViewModel> Search(LabelTypeSerachModel command)
        {
            var query = _LabelTypeReposytory.GetAll();
            if (Equals(!string.IsNullOrWhiteSpace(command.Name)))
            {
                query = query.Where(x => x.Name.ToLower().Contains(command.Name.ToLower())).ToList();
            }

            if (command.HallID>0)
            {
                query = query.Where(x => x.HallID == command.HallID).ToList();
            }

            return query.OrderByDescending(x => x.ID).Select(x => new LabelTypeViewModel
            {
                Name = x.Name,
                URlFile = x.LabelURL,
                CreationDateTime = x.CreaationDateTime.ToFarsi(),
                HallName = _hallReposytory.GetBy(z=>z.ID==x.HallID).Name,
                ID = x.ID,
                IsRemove = x.IsDeleted

            }).ToList();
        }
    }
}
