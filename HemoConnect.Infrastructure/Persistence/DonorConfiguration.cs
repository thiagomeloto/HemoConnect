using HemoConnect.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemoConnect.Infrastructure.Persistence
{
    public class DonorConfiguration : IEntityTypeConfiguration<Donor>
    {
        public void Configure(EntityTypeBuilder<Donor> builder)
        {
            builder.ToTable(nameof(Donor));

            builder.HasKey(d => d.Id);

            builder.Property(d => d.FullName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(d => d.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.Gener)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(d => d.BloodType)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.RHFactor)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.FullName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(d => d.FullName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(d => d.BirthDate)
                .IsRequired();

            builder.HasOne(d => d.Address)
               .WithOne(a => a.Donor)
               .HasForeignKey<Address>(a => a.Id);
        }
    }
}
