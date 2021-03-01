using System;
using Entities.Concrete;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class YumYumContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\mssqllocaldb;Database = YumYum;Trusted_Connection = true");// Hangi veritabanı ile ilişkili olduğunu belirttiğimiz yer.

        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
    }
}
