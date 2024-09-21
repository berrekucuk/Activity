using Activity.DAL.ORM;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity.BLL
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        public TEntity Add(TEntity entity);
        public List<TEntity> GetAll(int pageNumber, int pgeSize);
        public List<TEntity> GetAll();
        public TEntity GetById(Guid id);
        public void Remove(Guid id);
        public TEntity Update(TEntity entity);
        public List<TEntity> GetAllWithIncludes(params string[] includes);
    }
}
