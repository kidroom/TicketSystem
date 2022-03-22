using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;

namespace Repository
{
    public class MsDbContext : DbContext
    {
        public MsDbContext(DbContextOptions<MsDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TicketList>().HasKey(t => new { t.TicketId });
        }

        public DbSet<TicketList> TicketList { get; set; }
    }
}
