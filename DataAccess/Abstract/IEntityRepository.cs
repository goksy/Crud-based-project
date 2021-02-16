using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{ 
    // generic constraints
    // class : referans tip olabilir.
    // IEntity olarabilir veya ipmlemente eden bir nesne olabilir.
    // new():  newlenebilir olmali, interface newlenemedigi icin dataaccessde gelmiyor.
    public interface IEntityRepository<T> where T:class, IEntity, new()

    {
       
        // get everything
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
       

    }
}
