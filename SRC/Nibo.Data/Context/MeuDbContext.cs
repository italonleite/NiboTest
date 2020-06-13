using Microsoft.EntityFrameworkCore;
using Nibo.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nibo.Data.Context
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options)
      : base(options)
        { }

        public DbSet<BankStatement> BankStatements { get; set; }
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
