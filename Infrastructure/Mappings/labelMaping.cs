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
    public class labelMaping : IEntityTypeConfiguration<Domain.label>
    {
        public void Configure(EntityTypeBuilder<label> builder)
        {
            builder.HasKey(x => x.ID);
            builder.ToTable("LabelData");

            builder.Property(x => x.Interwoven).HasMaxLength(30).IsRequired();
            builder.Property(x => x.Den).HasMaxLength(8);
            builder.Property(x => x.Filament).HasMaxLength(8);
            builder.Property(x => x.Ply).HasMaxLength(8);
            builder.Property(x => x.Mingel).HasMaxLength(8);
            builder.Property(x => x.ColorCode).HasMaxLength(30);
            builder.Property(x => x.Emptyfield1).HasMaxLength(30);
            builder.Property(x => x.Emptyfield2).HasMaxLength(30);
            builder.Property(x => x.Emptyfield3).HasMaxLength(30);
            builder.Property(x => x.Emptyfield4).HasMaxLength(30);
            builder.Property(x => x.Emptyfield5).HasMaxLength(30);
            builder.Property(x => x.Description).HasMaxLength(200);
            builder.Property(x => x.direction).HasMaxLength(5);


            builder.HasOne(x => x.Machine).WithMany(x => x.Labels).HasForeignKey(x => x.MachineID);

        }
    }
}
