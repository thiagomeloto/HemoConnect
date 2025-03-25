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
    public class BloodStockConfiguration : IEntityTypeConfiguration<BloodStock>
    {
        public void Configure(EntityTypeBuilder<BloodStock> builder)
        {
            builder.ToTable(nameof(BloodStock));

            builder.HasKey(d => d.Id);

            builder.Property(d => d.BloodType)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(d => d.RHFactor)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(d => d.AmountML)
                .IsRequired();                
        }
    }
}
