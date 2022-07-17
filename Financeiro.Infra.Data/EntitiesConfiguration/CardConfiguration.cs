using Financeiro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financeiro.Infra.Data.EntitiesConfiguration
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Number).HasMaxLength(16).IsRequired();
            builder.Property(p => p.Limit).IsRequired();

            builder.HasMany(e => e.Purchases).WithOne(e => e.Card)
                .HasForeignKey(e => e.CardId);
        }
    }
}