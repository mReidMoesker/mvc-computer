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
    }
}
