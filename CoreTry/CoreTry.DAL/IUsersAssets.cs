using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTry.DAL
{
   public interface IUsersAssets
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Add(User user);
        void Delete(int id);
        void Update(User user);
        void Save();

    }
}
