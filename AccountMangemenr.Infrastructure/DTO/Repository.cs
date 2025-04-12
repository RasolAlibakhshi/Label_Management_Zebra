using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using _0_FrameWork;
using AccountManagement.Contract.Acconut;
using AccountManagement.Domian;
using AccountMangemenr.Infrastructure;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.DTO
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        private readonly AccountContext _accountContext;

        public Repository(AccountContext accountContext)
        {
            _accountContext = accountContext;
        }

        public void Create(TEntity entity)
        {
            _accountContext.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _accountContext.Set<TEntity>().Entry(entity).State = EntityState.Deleted;
        }

        public void DeleteByID(int id)
        {
            _accountContext.Accounts.Entry(_accountContext.Accounts.FirstOrDefault(x => x.ID==id)).State = EntityState.Deleted;
        }

        public void Dispose()
        {
            _accountContext.DisposeAsync();
        }

        public bool Exist(Expression<Func<TEntity, bool>> Filter)
        {
            return _accountContext.Set<TEntity>().Any(Filter);
        }

        public List<TEntity> GetAll()
        {
            return _accountContext.Set<TEntity>().ToList();
        }

        public TEntity GetBy(Expression<Func<TEntity, bool>> Filter)
        {
            return _accountContext.Set<TEntity>().FirstOrDefault(Filter);
        }

        public EditAccount GetDetails(long ID)
        {
            var data=_accountContext.Accounts.FirstOrDefault(x => x.ID == ID);
            return new EditAccount
            {
                FullName = data.FullName,
                ID = data.ID,
                
                Password = data.Password,
                RoleID = data.RoleID,
                UserName = data.UserName,
                ProfilePhoto = StringToFormFile.ConvertStringToIFormFile(data.ProfilePhoto,"")
            };
        }

        public void SaveChanges()
        {
            _accountContext.SaveChangesAsync();
        }

        public List<AccountViewModel> Search(SearchModel command)
        {
            var query = _accountContext.Accounts.Where(x=>x.IsDeleted==false).Select(x=>new AccountViewModel
            {
                ProfilePhoto = x.ProfilePhoto,
                FullName = x.FullName,
                UserName = x.UserName,
                RoleID = x.RoleID,
                RoleName = "مدیر سیستم",
                ID = x.ID 
            });
            if (!string.IsNullOrWhiteSpace(command.FullName))
            {
                query = query.Where(x => x.FullName.ToLower().Contains(command.FullName.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(command.UserName))
            {
                query = query.Where(x => x.UserName .ToLower().Contains(command.UserName.ToLower()));
            }

            if (command.RoleID>0)
            {
                query = query.Where(x => x.RoleName == "Name");
            }
            return query.ToList();
        }

        

        public void Update(TEntity entity)
        {
            _accountContext.Set<TEntity>().Entry(entity).State= EntityState.Modified;
        }
    }
}
