using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> where TEntity : class, IEntity, new() where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //IDisposable pattern implementation of c#
            using (TContext context = new TContext()) // Belleği hızlıca tamizlemek için using kullanıyoruz.
            {                                                       //Using kullanıldıktan sonra garbage collectoraı çağırır ve çöpe girer.
                var addedEntity = context.Entry(entity); // Referansla kontrol ediyoruz.
                addedEntity.State = EntityState.Added; // Durumunu ekle yapıyoruz
                context.SaveChanges(); // İşlemi tamamlıyoruz.
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext()) // Belleği hızlıca tamizlemek için using kullanıyoruz.
            {                                                       //Using kullanıldıktan sonra garbage collectoraı çağırır ve çöpe girer.
                var deletedEntity = context.Entry(entity); // Referansla kontrol ediyoruz.
                deletedEntity.State = EntityState.Deleted; // Durumunu silme yapıyoruz
                context.SaveChanges(); // İşlemi tamamlıyoruz.
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext()) // Belleği hızlıca tamizlemek için using kullanıyoruz.
            {                                                       //Using kullanıldıktan sonra garbage collectoraı çağırır ve çöpe girer.
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext()) // Belleği hızlıca tamizlemek için using kullanıyoruz.
            {                                                       //Using kullanıldıktan sonra garbage collectoraı çağırır ve çöpe girer.
                return filter == null ? context.Set<TEntity>().ToList() // ? ile nullmı sorgusu yapıyoruz, öyleyse List şeklinde hepsini veriyoruz.
                    : context.Set<TEntity>().Where(filter).ToList();   // : ile ise null değilse where ile getirilen koşula göre listeyi ver demek.
            }
        }

        public List<TEntity> GetAllByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext()) // Belleği hızlıca tamizlemek için using kullanıyoruz.
            {                                                       //Using kullanıldıktan sonra garbage collectoraı çağırır ve çöpe girer.
                var updatedEntity = context.Entry(entity); // Referansla kontrol ediyoruz.
                updatedEntity.State = EntityState.Modified; // Durumunu güncelle yapıyoruz
                context.SaveChanges(); // İşlemi tamamlıyoruz.
            }
        }
    }
}
