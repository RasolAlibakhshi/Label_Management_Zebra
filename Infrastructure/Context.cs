using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class Context:DbContext
    {
        public DbSet<Hall> Halls { get; set; }
        public DbSet<label> Labels { get; set; }
        public DbSet<LabelType> LabelTypes { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public Context(DbContextOptions<Context> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HallMapping).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
