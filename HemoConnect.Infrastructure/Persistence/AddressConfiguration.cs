using HemoConnect.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemoConnect.Infrastructure.Persistence
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable(nameof(Address));

            builder.HasKey(d => d.Id);

            builder.Property(d => d.PublicPlace)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(d => d.City)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.State)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.PostalCode)
                .IsRequired()
                .HasMaxLength(100);

            // 🔹 Configurando relação 1-para-1 com Donor
            builder.HasOne(a => a.Donor)
                   .WithOne(d => d.Address)
                   .HasForeignKey<Address>(a => a.Id) // Address usa Id como chave estrangeira
                   .OnDelete(DeleteBehavior.Cascade); // Exclui o Address se o Donor for removido
        }
    }
}
