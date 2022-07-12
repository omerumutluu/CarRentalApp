using CarRentalApp.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalApp.DataAccess.Abstracts
{
    public interface IGenericDal<T>
        where T : class, IEntity, new()
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity); 
    }
}
