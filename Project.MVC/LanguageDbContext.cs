using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project.MVC
{
    public partial class LanguageDbContext : DbContext
    {
        public LanguageDbContext()
        {
        }

        public LanguageDbContext(DbContextOptions<LanguageDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Content> Contents { get; set; } = null!;
        public virtual DbSet<News> News { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=MSI;Database=LanguageDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Content>(entity =>
            {
                entity.ToTable("Content");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnType("text")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Category)
                    .HasMaxLength(50)
                    .HasColumnName("category");

                entity.Property(e => e.ContentId).HasColumnName("contentId");

                entity.Property(e => e.Detail)
                    .HasColumnType("text")
                    .HasColumnName("detail");

                entity.Property(e => e.ImageUrls).HasColumnName("image_urls");

                entity.Property(e => e.LanguageCode)
                    .HasMaxLength(5)
                    .HasColumnName("language_code");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .HasColumnName("title");

                entity.HasOne(d => d.Content)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.ContentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__News__contentId__66603565");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
