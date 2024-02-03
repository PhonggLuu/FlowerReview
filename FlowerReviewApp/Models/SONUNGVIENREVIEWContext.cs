using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FlowerReviewApp.Models
{
    public partial class SONUNGVIENREVIEWContext : DbContext
    {
        public SONUNGVIENREVIEWContext()
        {
        }

        public SONUNGVIENREVIEWContext(DbContextOptions<SONUNGVIENREVIEWContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<DetailedProduct> DetailedProducts { get; set; } = null!;
        public virtual DbSet<DetailedProductOwner> DetailedProductOwners { get; set; } = null!;
        public virtual DbSet<Owner> Owners { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Reviewer> Reviewers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }
        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", true, true)
                        .Build();
            var strConn = config["ConnectionStrings:DefaultConnection"];

            return strConn;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetailedProductOwner>(entity =>
            {
                entity.HasKey(po => new { po.DetailedProductId, po.OwnerId });

                entity.ToTable("DetailedProductOwner");

                entity.Property(e => e.DetailedProductId).HasColumnName("DetailedProductID");

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.HasOne(d => d.DetailedProduct)
                    .WithMany(p => p.DetailedProductOwners)
                    .HasForeignKey(d => d.DetailedProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DetailedP__Detai__4BAC3F29");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.DetailedProductOwners)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DetailedP__Owner__4AB81AF0");
            });
        }
    }
}
