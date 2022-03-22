using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Repository.Models;
using System;

namespace Repository
{
    public class MsDbContext : DbContext
    {
        private IDbContextTransaction _transaction;
        public MsDbContext(DbContextOptions<MsDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TicketList>().HasKey(t => new { t.TicketId });
        }

        public DbSet<TicketList> TicketList { get; set; }

        public void BeginTransaction()
        {
            _transaction = Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                SaveChanges();
                _transaction.Commit();
            }
            finally
            {
                _transaction.Dispose();
            }
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }

        public void TransactionDispose()
        {
            _transaction.Dispose();
        }
    }
}
