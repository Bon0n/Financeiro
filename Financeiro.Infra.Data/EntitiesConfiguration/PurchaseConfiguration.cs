using Financeiro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financeiro.Infra.Data.EntitiesConfiguration
{
    public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(100);
            builder.Property(p => p.Price).HasPrecision(10,2).IsRequired();
            builder.Property(p => p.Installments).HasMaxLength(10);

            builder.HasOne(e => e.Card).WithMany(p => p.Purchases)
                .HasForeignKey(e => e.CardId);
        }
    }
}