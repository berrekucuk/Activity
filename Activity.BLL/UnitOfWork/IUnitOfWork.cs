using Activity.BLL.Repository;
using Activity.DAL.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity.BLL
{
    public interface IUnitOfWork
    {
        public GenericRepository<Category> CategoryRepository { get; }
        public GenericRepository<User> UserRepository { get; }
        public GenericRepository<Blog> BlogRepository { get; }
        public GenericRepository<Activity.DAL.ORM.Activity> ActivityRepository { get; }
        void Save();
    }
}
