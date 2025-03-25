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
    public class DonationConfiguration : IEntityTypeConfiguration<Donation>
    {
        public void Configure(EntityTypeBuilder<Donation> builder)
        {
            builder.ToTable(nameof(Donation));

            builder.HasKey(d => d.Id);

            builder.Property(d => d.DonorId)
                .IsRequired();

            builder.Property(d => d.DonationDate)
                .IsRequired();

            builder.Property(d => d.AmountML)
                .IsRequired();
        }
    }
}
