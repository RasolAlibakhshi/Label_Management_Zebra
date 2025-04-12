using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DTO
{
    public class Repository<TEntity>:IRepository<TEntity> where TEntity : Base
    {
        private Context _context;
        

        public Repository(Context context)
        {
            _context = context;
            
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity GetBy(Expression<Func<TEntity, bool>> Filter)
        {
            return  _context.Set<TEntity>().FirstOrDefault(Filter);
        }

        public TEntity Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            _context.Set<TEntity>().Entry(entity).State= EntityState.Modified;
            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            _context.Set<TEntity>().Entry(entity).State=EntityState.Deleted;
            return entity;
        }

        public void DeleteByID(int id)
        {
            _context.Set<TEntity>().Entry(GetBy(x=>x.ID==id)).State= EntityState.Deleted;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public bool Exist(Expression<Func<TEntity, bool>> Filter)
        {
            return _context.Set<TEntity>().Any(Filter);
        }
    }
}
