using CoreTry.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CoreTry.Services
{
    public class UserAssetsServices : IUsersAssets
    {
        private UserColorContext db;
        public UserAssetsServices(UserColorContext _db)
        {
            db = _db;
        }
        public void Add(User user)
        {
            db.Users.Add(user);
        }

        public void Delete(int id)
        {
            var User = GetById(id);
            if (User!=null)
            {
                db.Users.Remove(User);
            }
        }

        public IEnumerable<User> GetAll()
        {
            var users = db.Users.Include(c => c.Color)
                        .AsNoTracking();
            return users;
        }

        public User GetById(int id)
        {
            return db.Users.FirstOrDefault(x => x.ID == id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(User user)
        {
            var USER = GetById(user.ID);
            if (USER!=null)
            {
                db.Entry(USER).CurrentValues.SetValues(user);
            }
        }
    }
}
