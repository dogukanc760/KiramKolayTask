using Core.Entities;
using Core.Entities.Concrete;

using Entities.Concrete;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                (@"Server=.\MSSQLSERVER2;Database=NewTask;Trusted_Connection=true");
        }

        public DbSet<Sehirler> Sehirlers { get; set; }
        public DbSet<SehirlerHavaDurumlari> SehirlerHavaDurumlari { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

      
        public DbSet<SysLog> SysLogs { get; set; }
    }
}
