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
    public class LabelTypeMapping : IEntityTypeConfiguration<Domain.LabelType>
    {
        public void Configure(EntityTypeBuilder<LabelType> builder)
        {
            builder.HasKey(x => x.ID);
            builder.ToTable("LabelType");
            builder.Property(x => x.Name).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(80);
            builder.HasOne(x => x.Hall).WithMany(x => x.LabelTypes).HasForeignKey(x => x.HallID);
        }
    }
}
