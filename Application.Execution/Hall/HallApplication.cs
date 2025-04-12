using _0_Framework.Application;
using Application.Contracts.Hall;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.DTO;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Execution.Hall
{
    public class HallApplication : IHallApplication
    {
        private readonly IRepository<Domain.Hall> _hallRepository;

        public HallApplication(IRepository<Domain.Hall> hallRepository)
        {
            _hallRepository = hallRepository;
        }
        public OpreationResult Create(CreateHall command)
        {
            var Opretion = new OpreationResult();
            if (command==null)
            {
                return Opretion.Failed(ApplicationMessages.InputNull);
            }
            if (_hallRepository.Exist(x=>x.Name==command.Name))
            {
                return Opretion.Failed(ApplicationMessages.DuplicatedRecord);
            }
                _hallRepository.Create(new Domain.Hall(command.Name));
                _hallRepository.SaveChanges();
                return Opretion.Success();
            
        }

        public OpreationResult Edit(EditHall command)
        {
            var Opretion = new OpreationResult();
            if (command==null)
            {
                return Opretion.Failed(ApplicationMessages.InputNull);
            }
            if (_hallRepository.Exist(x => x.Name==command.Name && x.ID!=command.ID))
            {
                return Opretion.Failed(ApplicationMessages.DuplicatedRecord);
            }
            _hallRepository.GetBy(x=>x.ID==command.ID).Edit(command.Name);
            _hallRepository.SaveChanges();
            return Opretion.Success();
        }

        public EditHall GetDetails(long id)
        {
            var data=_hallRepository.GetBy(x => x.ID == id);
            return new EditHall {ID = data.ID,Name = data.Name};
        }

        public List<HallViewModel> Search(HallSearchModel command)
        {
            var query = _hallRepository.GetAll();
            if (!string.IsNullOrWhiteSpace(command.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(command.Name.ToLower())).ToList();
            }

            return query.OrderByDescending(x => x.ID).Select(x => new HallViewModel
                { Name = x.Name, CreationDateTime = x.CreaationDateTime.ToFarsi(),IsRemove = x.IsDeleted,ID = x.ID}).ToList();
        }

        public void Remove(long id)
        {
            _hallRepository.GetBy(x => x.ID == id).Remove();
            _hallRepository.SaveChanges();
        }

        public void Restore(long id)
        {
            _hallRepository.GetBy(x => x.ID == id).Restore();
            _hallRepository.SaveChanges();
        }
    }
}
