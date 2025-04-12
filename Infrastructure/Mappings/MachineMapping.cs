
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class MachineMapping : IEntityTypeConfiguration<Domain.Machine>
    {
        public void Configure(EntityTypeBuilder<Machine> builder)
        {
            builder.HasKey(x => x.ID);
            builder.ToTable("Machines");

            builder.Property(x => x.Name).HasMaxLength(20).IsRequired();

            builder.HasMany(x => x.Labels).WithOne(x => x.Machine).HasForeignKey(x => x.MachineID);
            builder.HasOne(x => x.Hall).WithMany(x => x.Machines).HasForeignKey(x => x.HallID);
        }
    }
}
