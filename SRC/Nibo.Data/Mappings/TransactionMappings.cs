using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nibo.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nibo.Data.Mappings
{
    public class TransactionMappings : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Type)
               .HasColumnType("varchar(10)")
               .HasColumnName("TRNTYPE");

            builder.Property(t => t.TransactionPostDate)
                .HasColumnType("datetime")
                .HasColumnName("DTPOSTED");

            builder.Property(t => t.Amount)
              .HasColumnType("decimal(5,2)")
               .HasColumnName("TRNAMT");

            builder.Property(t => t.Memo)
              .HasColumnType("varchar(100)")
               .HasColumnName("MEMO");

            builder.HasOne(b => b.BankStatement)
                .WithMany(t => t.Transactions);
                
        }
    }
}
