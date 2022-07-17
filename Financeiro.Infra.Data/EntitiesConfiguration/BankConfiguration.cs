using Financeiro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financeiro.Infra.Data.EntitiesConfiguration
{
    public class BankConfiguration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();

            builder.HasMany(e => e.Cards).WithOne(e => e.Bank)
                .HasForeignKey(e => e.BankId);
            
            builder.HasOne(e => e.Person).WithMany(e => e.Banks)
                .HasForeignKey(e => e.PersonId);
        }
    }
}