using netCore_efcore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace netCore_efcore.Repository.Interfaces
{
    public interface  IRepository<T> where T: BaseModel
    {
        T GetById(string id);
        IEnumerable<T> List();
        IEnumerable<T> List(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);

    }
}
