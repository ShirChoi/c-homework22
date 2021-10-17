using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace homework22 {
    public partial class EFCtestContext : DbContext {

        public virtual DbSet<Student> Students { get; set; }

        public EFCtestContext() { }

        public EFCtestContext(DbContextOptions<EFCtestContext> options) 
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {  
                optionsBuilder.UseSqlServer("Server=DESKTOP-CT0BSVJ\\DEV;Database=EFC test;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
