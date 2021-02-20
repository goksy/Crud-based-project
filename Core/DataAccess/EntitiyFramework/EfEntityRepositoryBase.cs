using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntitiyFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext>:IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            // IDisposable pattern implementation of C# after using garbage collector collect that
            using (TContext context = new TContext())
            {
                // referansi yakala esitler var ile
                var addedEntity = context.Entry(entity);
                // referansi sitledigin varible a entitiy durumunu ekle
                addedEntity.State = EntityState.Added;
                // degisiklikleri kaydet
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            // IDisposable pattern implementation of C# after using garbage collector collect that
            using (TContext context = new TContext())
            {
                // referansi yakala esitler var ile
                var deletedEntity = context.Entry(entity);
                // referansi sitledigin varible a entitiy durumunu sil
                deletedEntity.State = EntityState.Deleted;
                // degisiklikleri kaydet
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            // tek data cekecek
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                //eger filtre null degilse, dbset product tablolari listle
                return filter == null
                    // filter null ise
                    ? context.Set<TEntity>().ToList()
                    // degilse
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public List<TEntity> GetAllByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            // IDisposable pattern implementation of C# after using garbage collector collect that
            using (TContext context = new TContext())
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
