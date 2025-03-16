using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PcPartsDatbase.Models;

namespace PcPartsDatabase.DAL
{
    public class PcPartsDatabaseDbContext : DbContext
    {
        public PcPartsDatabaseDbContext(DbContextOptions<PcPartsDatabaseDbContext> options) : base(options) { }

        public DbSet<Computer> Computers { get; set; }
        public DbSet<GraphicsCard> GraphicsCards { get; set; }
        public DbSet<OperatingSys> OperatingSystem { get; set; }
        public DbSet<Storage> Storage { get; set; }
        public DbSet<Sys> System { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // primary keys (computer extends system)
            modelBuilder.Entity<Sys>().HasKey(s => s.SystemID);
            modelBuilder.Entity<Computer>().HasKey(c => c.SystemID);

            modelBuilder.Entity<GraphicsCard>().HasKey(g => g.GraphicsID);
            modelBuilder.Entity<OperatingSys>().HasKey(os => os.OsID);
            modelBuilder.Entity<Processor>().HasKey(p => p.ProcessorID);
            modelBuilder.Entity<Storage>().HasKey(s => s.StorageID);

            // foreign keys
            modelBuilder.Entity<Computer>()
                .HasOne(c => c.Processor)
                .WithMany()
                .HasForeignKey("ProcessorID");

            modelBuilder.Entity<Computer>()
                .HasOne(c => c.GraphicsCard)
                .WithMany()
                .HasForeignKey("GraphicsID");

            modelBuilder.Entity<Computer>()
                .HasOne(c => c.OperatingSystems)
                .WithMany()
                .HasForeignKey("OsID");

            modelBuilder.Entity<Computer>()
                .HasMany(c => c.Storage)
                .WithOne()
                .HasForeignKey("StorageID");
        }
    }
}
