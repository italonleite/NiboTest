using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nibo.Business.Models;

namespace Nibo.Data.Mappings
{
    public class BankStatementMappings : IEntityTypeConfiguration<BankStatement>
    {
        public void Configure(EntityTypeBuilder<BankStatement> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasMany(t => t.Transactions)
                 .WithOne(b => b.BankStatement)
                 .HasForeignKey(b => b.BankStatementId);

            builder.ToTable("BankStatements");
        }
    }
}
