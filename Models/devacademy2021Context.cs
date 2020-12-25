using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace NamesApplication.Models
{
    public partial class devAcademy2021Context : DbContext
    {
        public devAcademy2021Context()
        {
        }

        public devAcademy2021Context(DbContextOptions<devAcademy2021Context> options)
            : base(options)
        {
        }

        public virtual DbSet<NamesTable> NamesTables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-35CADGH\\SQLEXPRESS;Database=devAcademy2021;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Finnish_Swedish_CI_AS");

            modelBuilder.Entity<NamesTable>(entity =>
            {
                entity.HasKey(e => e.NameGuid)
                    .HasName("PK__namesTab__6D00BE3E94800CAB");

                entity.ToTable("namesTable");

                entity.Property(e => e.NameGuid)
                    .HasColumnName("nameGuid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Names)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("names");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
