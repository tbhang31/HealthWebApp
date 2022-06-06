using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using liftoffHealthCare.Models;

namespace liftoffHealthCare.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Vital> Vitals { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<VitalMedication> VitalMedications { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VitalMedication>()
                .HasKey(v => new { v.VitalId, v.MedicationId });
            base.OnModelCreating(modelBuilder);
        }
    }
}

