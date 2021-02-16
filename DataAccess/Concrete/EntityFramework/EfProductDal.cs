using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{

    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            // IDisposable pattern implementation of C# after using garbage collector collect that
            using (NorthwindContext context = new NorthwindContext())
            {
               // referansi yakala esitler var ile
                var addedEntity = context.Entry(entity);
                // referansi sitledigin varible a entitiy durumunu ekle
                addedEntity.State = EntityState.Added;
                // degisiklikleri kaydet
                context.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            // IDisposable pattern implementation of C# after using garbage collector collect that
            using (NorthwindContext context = new NorthwindContext())
            {
                // referansi yakala esitler var ile
                var deletedEntity = context.Entry(entity);
                // referansi sitledigin varible a entitiy durumunu sil
                deletedEntity.State = EntityState.Deleted;
                // degisiklikleri kaydet
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            // tek data cekecek
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using(NorthwindContext context = new NorthwindContext())
            {
                //eger filtre null degilse, dbset product tablolari listle
                return filter == null 
                    // filter null ise
                    ? context.Set<Product>().ToList() 
                    // degilse
                    : context.Set<Product>().Where(filter).ToList();
            }
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            // IDisposable pattern implementation of C# after using garbage collector collect that
            using (NorthwindContext context = new NorthwindContext())
            {
                // referansi yakala esitler var ile
                var updatedEntity = context.Entry(entity);
                // referansi sitledigin varible a entitiy durumunu ekle
                updatedEntity.State = EntityState.Modified;
                // degisiklikleri kaydet
                context.SaveChanges();
            }
        }
    }
}
