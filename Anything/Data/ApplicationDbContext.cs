using Anything.Entities;
using Anything.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Anything.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<ProcessM> processMs { get; set; }
        public DbSet<Draw> Draws { get; set; }
        public DbSet<ProductMaster> ProductMasters { get; set; }
        public DbSet<StageMaster> StageMasters { get; set; }
        public DbSet<Gzie> Group { get; set; }
        public DbSet<Rs> Rss { get; set; }
        public DbSet<LineMaster> LineMasters { get; set; }
        public DbSet<SelectShift> SelectShifts { get; set; }
        public DbSet<Operate> Operates { get; set; }

        public DbSet<OrderMaster> OrderMasters { get; set; }

        public DbSet<OrderMDetail> OrderMDetails { get; set; }
        public DbSet<QcMaster> QcMasters { get; set; }

        public DbSet<UserAccount> UserAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<StageConn> StageConns{ get; set; }

        public DbSet<ProcessPage> ProcessPages { get; set; }



    }
}
