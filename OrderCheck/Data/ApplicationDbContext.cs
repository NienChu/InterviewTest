using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrderCheck.Model.DataModel;
using System;

namespace OrderCheck.Data {
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid, IdentityUserClaim<Guid>,
        IdentityUserRole<Guid>, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>> {

        public ApplicationDbContext(DbContextOptions options)
            : base(options) {
        }

        public ApplicationDbContext(): base() {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            builder.Entity<Order>(b => {
                b.Property(p => p.CreateDateTime).HasDefaultValueSql("GETUTCDATE()");

                b.HasOne(p => p.Owner)
                .WithMany(p => p.Orders)
                .HasForeignKey(p => p.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<OrderItem>(b => {
                b.HasOne(p => p.Order)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(p => p.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

                b.HasOne(p => p.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Product>(b => {
                b.Property(p => p.CreateDateTime).HasDefaultValueSql("GETUTCDATE()");
                b.Property(p => p.UpdateDateTime).HasDefaultValueSql("GETUTCDATE()");
            });
        }
    }
}
