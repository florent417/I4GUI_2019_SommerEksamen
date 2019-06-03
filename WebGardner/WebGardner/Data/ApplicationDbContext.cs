using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebGardner.Models;

namespace WebGardner.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Tree>()
                .HasOne(l => l.Location)
                .WithMany(t => t.Trees)
                .HasForeignKey(l => l.LocationId);

            builder.Entity<Sensor>()
                .HasOne(l => l.Location)
                .WithMany(s => s.Sensors)
                .HasForeignKey(l => l.LocationId);
        }
    }
}
