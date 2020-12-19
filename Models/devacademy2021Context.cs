using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace NamesApplication.Models
{
    public partial class devacademy2021Context : DbContext
    {
        public devacademy2021Context()
        {
        }

        public devacademy2021Context(DbContextOptions<devacademy2021Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Name> Names { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-35CADGH\\SQLEMA;Database=dev-academy-2021;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Finnish_Swedish_CI_AS");

            modelBuilder.Entity<Name>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Name1)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.NameGuid).HasColumnName("nameGuid");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
