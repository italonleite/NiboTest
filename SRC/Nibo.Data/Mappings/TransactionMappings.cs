using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nibo.Business.Models;

namespace Nibo.Data.Mappings
{
    public class TransactionMappings : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Type)
               .HasColumnType("integer")
               .HasColumnName("Trntype");

            builder.Property(t => t.TransactionPostDate)
                .HasColumnType("datetime")
                .HasColumnName("Dtposted");

            builder.Property(t => t.Amount)
              .HasColumnType("decimal")
               .HasColumnName("Trnamt");

            builder.Property(t => t.Memo)
              .HasColumnType("varchar(100)")
               .HasColumnName("Memo");

            builder.HasOne(b => b.BankStatement)
                .WithMany(t => t.Transactions);

            builder.ToTable("Transactions");

        }
    }
}
