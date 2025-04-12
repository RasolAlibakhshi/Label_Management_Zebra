using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using AccountManagement.Contract.Acconut;
using AccountManagement.Domian;


namespace Infrastructure.DTO
{
    public interface IRepository<TEntity>:IDisposable where TEntity : EntityBase
    {
        List<TEntity> GetAll();
        TEntity GetBy(Expression<Func<TEntity, bool>> Filter);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        bool Exist(Expression<Func<TEntity, bool>> Filter);
        void DeleteByID(int id);

        EditAccount GetDetails(long ID);
        List<AccountViewModel> Search(SearchModel command);
        

        void SaveChanges();
    }
}
