using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nibo.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nibo.Data.Mappings
{
    public class BankStatementMappings : IEntityTypeConfiguration<BankStatement>
    {
        public void Configure(EntityTypeBuilder<BankStatement> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
               .HasColumnType("varchar(100)")
               .HasColumnName("NAME");

            builder.Property(b => b.StatementStart)
                .HasColumnType("datetime")
                .HasColumnName("DTSTART");

            builder.Property(b => b.StatementEnd)
               .HasColumnType("datetime")
               .HasColumnName("DTEND");

            builder.HasMany(t => t.Transactions)
                .WithOne(b => b.BankStatement)
                .HasForeignKey(b => b.BankStatementId);

            builder.ToTable("BankStatements");
        }
    }
}
