using _0_Framework.Application;
using Application.Contracts.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.DTO;
using Application.Contracts.Hall;

namespace Application.Execution.Machine
{
    public class MachineApplication : IMachineApplication
    {
        private readonly IRepository<Domain.Machine> _MachineRepository;
        private readonly IRepository<Domain.Hall> _hallRepository;

        public MachineApplication(IRepository<Domain.Machine> machineRepository, IRepository<Domain.Hall> hallRepository)
        {
            _MachineRepository = machineRepository;
            _hallRepository = hallRepository;
        }
        public OpreationResult Create(CreateMachine command)
        {
            var Opretion = new OpreationResult();
            if (command==null)
            {
                return Opretion.Failed(ApplicationMessages.InputNull);
            }
            if (_MachineRepository.Exist(x => x.Name==command.Name && x.HallID==command.HallID))
            {
                return Opretion.Failed(ApplicationMessages.DuplicatedRecord);
            }
            _MachineRepository.Create(new Domain.Machine(command.HallID,command.Name));
            _MachineRepository.SaveChanges();
            return Opretion.Success();
        }

        public OpreationResult Edit(EditMachine command)
        {
            var Opretion = new OpreationResult();
            if (command==null)
            {
                return Opretion.Failed(ApplicationMessages.InputNull);
            }
            if (_MachineRepository.Exist(x => x.Name==command.Name && x.ID!=command.ID))
            {
                return Opretion.Failed(ApplicationMessages.DuplicatedRecord);
            }
            _MachineRepository.GetBy(x => x.ID==command.ID).Edit(command.HallID,command.Name);
            _MachineRepository.SaveChanges();
            return Opretion.Success();
        }

        public EditMachine GetDetails(long id)
        {
            var data = _MachineRepository.GetBy(x => x.ID == id);
            return new EditMachine { ID = data.ID, Name = data.Name, HallID = data.HallID};
        }

        public List<HalSelectListModel> hallListModels()
        {
            return _hallRepository.GetAll().Select(x => new HalSelectListModel { ID = x.ID, Name = x.Name }).ToList();
        }

        public void Remove(long id)
        {
            _MachineRepository.GetBy(x => x.ID == id).Remove();
            _MachineRepository.SaveChanges();
        }

        public void Restore(long id)
        {
            _MachineRepository.GetBy(x => x.ID == id).Restore();
            _MachineRepository.SaveChanges();
        }

        public List<MachineViewModel> Search(MachineSearchModel command)
        {
            var query = _MachineRepository.GetAll();
            if (!string.IsNullOrWhiteSpace(command.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(command.Name.ToLower())).ToList();
            }

            if (command.HallID > 0)
            {
                query = query.Where(x=>x.HallID==command.HallID).ToList();
            }

            var machines = (from m in query
                join h in _hallRepository.GetAll() on m.HallID equals h.ID into halls
                from h in halls.DefaultIfEmpty()
                select new MachineViewModel
                {
                    ID = m.ID,
                    IsDeleted = m.IsDeleted,
                    Name = m.Name,
                    CreationDateTime = m.CreaationDateTime.ToFarsi(),
                    HallName = h != null ? h.Name : "نامشخص",
                    HallID = h != null ? h.ID : 0
                }).ToList();

            return machines;

        }
    }
}
