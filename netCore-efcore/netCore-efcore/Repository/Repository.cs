using Microsoft.EntityFrameworkCore;
using netCore_efcore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using netCore_efcore.Repository.Interfaces;
using netCore_efcore.Utils;

namespace netCore_efcore.Repository
{
   public class Repository<T> : IRepository<T> where T : BaseModel
   {
        private readonly EFCoreContext _dbContext;

        public Repository(EFCoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual T GetById(string id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> List()
        {
            return _dbContext.Set<T>().AsEnumerable();
        }

        public virtual IEnumerable<T> List(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>()
                    .Where(predicate)
                    .AsEnumerable();
        }

        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Edit(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }
   }
}

