using Activity.BLL.Repository;
using Activity.DAL.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity.BLL
{
    public class UnitOfWork : IUnitOfWork
    {
        private ActivityDbContext db = new ActivityDbContext();

        private GenericRepository<Category> categoryRepository;

        private GenericRepository<User> userRepository;
        private GenericRepository<Blog> blogRepository;
        private GenericRepository<Activity.DAL.ORM.Activity> activityRepository;

        public GenericRepository<Category> CategoryRepository
        {
            get
            {
                if(categoryRepository == null)
                {
                    categoryRepository = new GenericRepository<Category>();
                }
                return categoryRepository;
            }
        }
        public GenericRepository<User> UserRepository
        {
            get
            {
                if(userRepository == null)
                {
                    userRepository = new GenericRepository<User>();
                }
                return userRepository;
            }
        }

        public GenericRepository<Blog> BlogRepository
        {
            get
            {
                if(blogRepository == null)
                {
                    blogRepository = new GenericRepository<Blog>();
                }
                return blogRepository;
            }
        }

        public GenericRepository<Activity.DAL.ORM.Activity> ActivityRepository
        {
            get
            {
                if(activityRepository == null)
                {
                    activityRepository = new GenericRepository<Activity.DAL.ORM.Activity>();
                }
                return activityRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
       

    }
}
