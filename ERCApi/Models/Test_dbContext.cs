using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ERCApi.Models
{
    public partial class Test_dbContext : DbContext
    {
        public Test_dbContext()
        {
        }

        public Test_dbContext(DbContextOptions<Test_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Lc> Lcs { get; set; }
        public virtual DbSet<Resident> Residents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("DataSource=Database/Test_db.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lc>(entity =>
            {
                entity.ToTable("LC");

                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.AreaApart).HasColumnName("Area_apart");

                entity.Property(e => e.DateEnd)
                    .HasColumnType("date")
                    .HasColumnName("Date_end");

                entity.Property(e => e.DateStart)
                    .IsRequired()
                    .HasColumnType("date")
                    .HasColumnName("Date_start");

                entity.Property(e => e.NumLc)
                    .IsRequired()
                    .HasColumnName("Num_LC");

                entity.Property(e => e.ResidentId).HasColumnName("Resident_id");

                entity.HasOne(d => d.Resident)
                    .WithMany(p => p.Lcs)
                    .HasForeignKey(d => d.ResidentId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Resident>(entity =>
            {
                entity.ToTable("Resident");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Birthday).IsRequired();

                entity.Property(e => e.DateEndResidence).HasColumnName("Date_end_residence");

                entity.Property(e => e.DateStartResidence)
                    .IsRequired()
                    .HasColumnName("Date_start_residence");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("Last_name");

                entity.Property(e => e.Name).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
