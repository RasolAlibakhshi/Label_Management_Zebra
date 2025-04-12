using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class HallMapping : IEntityTypeConfiguration<Domain.Hall>
    {
        public void Configure(EntityTypeBuilder<Hall> builder)
        {
            builder.HasKey(x => x.ID);
            builder.ToTable("Halls");
            builder.Property(x => x.Name).HasMaxLength(20).IsRequired();


            builder.HasMany(x => x.Machines).WithOne(x => x.Hall).HasForeignKey(x => x.HallID);
            builder.HasMany(x => x.LabelTypes).WithOne(x => x.Hall).HasForeignKey(x => x.HallID);
        }
    }
}
