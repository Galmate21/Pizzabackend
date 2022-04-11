using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Bolt.Models
{
    public partial class boltContext : DbContext
    {
        public boltContext()
        {
        }

        public boltContext(DbContextOptions<boltContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Termekek> Termekeks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;database=bolt;user=root;password=;ssl mode=none;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Termekek>(entity =>
            {
                entity.ToTable("termekek");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Ar)
                    .HasColumnType("int(11)")
                    .HasColumnName("ar");

                entity.Property(e => e.Kep)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("kep");

                entity.Property(e => e.Leiras)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("leiras");

                entity.Property(e => e.Nev)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("nev");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
