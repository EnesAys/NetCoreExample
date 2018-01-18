using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTry.DAL
{
   public class UserColorContext:DbContext
    {
        public UserColorContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Color> Colors { get; set; }
    }
}
