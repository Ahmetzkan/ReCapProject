using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class RentACarContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RentACar;Trusted_Connection=true");
        }

        public DbSet<Vehicle>  Vehicles{ get; set; }
        public DbSet<Brand>  Brands{ get; set; }
        public DbSet<Model>  Models{ get; set; }
        public DbSet<Color>  Colors{ get; set; }
    }
}
