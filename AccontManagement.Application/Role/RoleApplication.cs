using _0_Framework.Application;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.Domain.RoleAgg;
using System.Collections.Generic;
using Infrastructure.DTO;
using System.Security;

namespace AccountManagement.Application
{
    public class RoleApplication : IRoleApplication
    {
        private readonly IRepository<Role> _repository;

        public RoleApplication(IRepository<Role> repository)
        {
            _repository = repository;
        }

        public OpreationResult Create(CreateRole command)
        {
            var operation = new OpreationResult();
            if (_repository.Exist(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            _repository.Create(new Role(command.Name,new List<Permission>()));
            _repository.SaveChanges();
            return operation.Success();
        }

        public OpreationResult Edit(EditRole command)
        {
            var operation = new OpreationResult();
            var role = _repository.GetBy(x=>x.ID==command.Id);
            if (role == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_repository.Exist(x => x.Name == command.Name && x.ID != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            

            role.Edit(command.Name, new List<Permission>());
            _repository.SaveChanges();
            return operation.Success();
        }

        public EditRole GetDetails(long id)
        {
            var data = _repository.GetBy(x => x.ID == id);
            return new EditRole
            {
                Id = data.ID,
                Name = data.Name,
                
            };
        }

        public List<RoleViewModel> List()
        {
            return _repository.GetAll().Select(x=>new RoleViewModel
            {
                Name = x.Name,
                Id = x.ID,
                CreationDate = x.CreaationDateTime.ToFarsi(),
                IsDeleted = x.IsDeleted
            }).ToList();
        }

        public void Remove(long id)
        {
            var data=_repository.GetBy(x => x.ID == id);
            if (data!=null)
            {
                data.Remove();
                _repository.SaveChanges();
            }
            
        }

        public void Restore(long id)
        {
            var data = _repository.GetBy(x => x.ID == id);
            if (data!=null)
            {
                data.Restore();
                _repository.SaveChanges();
            }
        }
    }
}