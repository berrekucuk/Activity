using Activity.DAL.ORM;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity.BLL.Repository
{
    public class GenericRepository<TEntity> where TEntity : BaseEntity
    {
        internal ActivityDbContext db;
        internal DbSet<TEntity> dbSet;

        public GenericRepository()
        {
            db = new ActivityDbContext();
            dbSet = db.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            entity.AddDate = DateTime.Now;
            entity.UpdateDate = DateTime.Now;
            entity.IsDeleted = false;
            dbSet.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public List<TEntity> GetAll()
        {
            var result = dbSet.Where(x => x.IsDeleted == false).ToList();
            return result;
        }

        public TEntity GetById(Guid id)
        {
            var result = dbSet.FirstOrDefault(x => x.ID == id &&  x.IsDeleted == false);
            return result;
        }

        public void Remove(Guid id)
        {
            var entity = dbSet.FirstOrDefault(x => x.ID == id && x.IsDeleted == false);
            entity.IsDeleted = true;
            entity.DeleteDate = DateTime.Now;
            db.SaveChanges();
        }

        public TEntity Update(TEntity entity)
        {
            entity.UpdateDate = DateTime.Now;
            dbSet.Update(entity);
            db.SaveChanges() ;
            return entity;
        }
    }
}
