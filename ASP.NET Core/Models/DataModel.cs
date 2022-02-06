using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core.Models
{
    public class DataModel
    {
        public class BloggingContext : DbContext
        {
            public DbSet<Profile> Profiles { get; set; }

            public string DbPath { get; }

            public BloggingContext()
            {
                var path = System.IO.Directory.GetCurrentDirectory();
                DbPath = System.IO.Path.Join(path, "db.db");
            }

            protected override void OnConfiguring(DbContextOptionsBuilder options)
                => options.UseSqlite($"Data Source={DbPath}");
        }

        public class Profile
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Age { get; set; }

        }
    }
}
