using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using Application.Contracts.Label;
using Application.Contracts.Machine;
using Domain;
using Infrastructure.DTO;

namespace Application.Execution.Label
{
    public class LabelApplication: ILabelApplication
    {
        private readonly IRepository<Domain.Machine> _MachineRepository;
        private readonly IRepository<Domain.Hall> _hallRepository;
        private readonly IRepository<Domain.label> _labelReoRepository;

        public LabelApplication(IRepository<Domain.Machine> machineRepository, IRepository<Domain.Hall> hallRepository, IRepository<label> labelReoRepository)
        {
            _MachineRepository = machineRepository;
            _hallRepository = hallRepository;
            _labelReoRepository = labelReoRepository;
        }
        public OpreationResult Create(CreateLabel command)
        {
            var Opretion = new OpreationResult();
            if (command==null)
            {
                return Opretion.Failed(ApplicationMessages.InputNull);
            }
            // if (_labelReoRepository.Exist(x => x.Interwoven==command.Interwoven))
            // {
            //     return Opretion.Failed(ApplicationMessages.DuplicatedRecord);
            // }
            _labelReoRepository.Create(new Domain.label(command.MachineID, command.Interwoven,command.Filament,command.Den,command.ColorCode
                ,command.Emptyfield1,command.Emptyfield2,command.Emptyfield3,command.Emptyfield4,command.Emptyfield5,command.Description,command.Mingel,command.YarnType,command.Ply,command.direction
                ));
            _MachineRepository.SaveChanges();
            return Opretion.Success();
        }

        public OpreationResult Edit(EditLabel command)
        {
            var Opretion = new OpreationResult();
            // if (command==null)
            // {
            //     return Opretion.Failed(ApplicationMessages.InputNull);
            // }
            // if (_labelReoRepository.Exist(x => x.Interwoven==command.Interwoven && x.ID!=command.ID))
            // {
            //     return Opretion.Failed(ApplicationMessages.DuplicatedRecord);
            // }
            _labelReoRepository.GetBy(x => x.ID==command.ID).Edit(command.MachineID, command.Interwoven, command.Filament, command.Den, command.ColorCode
                , command.Emptyfield1, command.Emptyfield2, command.Emptyfield3, command.Emptyfield4, command.Emptyfield5, command.Description,command.Mingel,command.YarnType,command.Ply,command.direction);
            _labelReoRepository.SaveChanges();
            return Opretion.Success();
        }

        public EditLabel GetDetails(long id)
        {
            var data = _labelReoRepository.GetBy(x => x.ID == id);
            return new EditLabel
            {
                ID = data.ID,
                MachineID = data.MachineID,
                Mingel = data.Mingel,
                ColorCode = data.ColorCode,
                Den = data.Den,
                Description = data.Description,
                Emptyfield1 = data.Emptyfield1,
                Emptyfield2 = data.Emptyfield2,
                Emptyfield3 = data.Emptyfield3,
                Emptyfield4 = data.Emptyfield4,
                Filament = data.Filament,
                Interwoven = data.Interwoven,
                direction = data.direction,
                Ply = data.Ply,
                YarnType = data.YarnType
            };
        }

        public List<HallSelctList> hallSelectList()
        {
            return _hallRepository.GetAll().Select(x => new HallSelctList { ID = x.ID, Name = x.Name }).ToList();
        }

        public List<MachineSelectList> machineSelectList(long id)
        {
            return _MachineRepository.GetAll().Where(x=>x.HallID==id).Select(x => new MachineSelectList { ID = x.ID, Name = x.Name }).ToList();
        }

        public void Remove(long id)
        {
            _labelReoRepository.GetBy(x => x.ID == id).Remove();
            _labelReoRepository.SaveChanges();
        }

        public void Restore(long id)
        {
            _labelReoRepository.GetBy(x => x.ID == id).Restore();
            _labelReoRepository.SaveChanges();
        }

        public List<LabelViewModel> Search(LabelSearchModel command)
        {
            var query = _labelReoRepository.GetAll();
            var HallQuery = _hallRepository.GetAll();
            var MachineQuery = _MachineRepository.GetAll();
            if (!string.IsNullOrWhiteSpace(command.Interwoven))
            {
                query = query.Where(x => x.Interwoven.ToLower().Contains(command.Interwoven.ToLower())).ToList();
            }

            if (command.MachineID > 0)
            {
                query = query.Where(x => x.MachineID == command.MachineID).ToList();
            }
            
            return query.OrderByDescending(x => x.ID).Select(x => new LabelViewModel
            {
                Interwoven = x.Interwoven
                ,CreationDateTime = x.CreaationDateTime.ToFarsi(),
                Filament = x.Filament,
                Den = x.Den,
                Ply = x.Ply,
                direction = x.direction,
                ColorCode = x.ColorCode,
                Emptyfield1 = x.Emptyfield1,
                Emptyfield2 = x.Emptyfield2,
                Emptyfield3 = x.Emptyfield3,
                Emptyfield4 = x.Emptyfield4,
                Emptyfield5 = x.Emptyfield5,
                Description = x.Description,
                MachineName = MachineQuery.FirstOrDefault(z => z.ID==x.MachineID).Name,

                HallName = HallQuery.FirstOrDefault(z=>z.ID==MachineQuery.FirstOrDefault(f => f.ID==x.MachineID).HallID).Name,
                Mingel = x.Mingel,
                IsDeleted = x.IsDeleted,
                ID = x.ID

            }).ToList();
        }
    }
}
