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

        
    }
}