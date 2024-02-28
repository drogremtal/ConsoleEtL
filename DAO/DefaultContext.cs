using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DefaultContext : DbContext
    {
        public DbSet<UniversitetDAO> Universitets { get; set; }

        public DefaultContext(DbContextOptions<DefaultContext> dbContext) :base(dbContext) 
        {
            Database.EnsureDeletedAsync();
            Database.EnsureCreatedAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql();
        }
    }
}
