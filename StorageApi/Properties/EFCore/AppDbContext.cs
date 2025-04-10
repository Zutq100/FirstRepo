using Microsoft.EntityFrameworkCore;
using StorageApi.Models;

namespace StorageApi.Properties.EFCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<StorageItem> StorageItems { get; set; }
    public DbSet<StorageMovement> StorageMovements { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StorageItem>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
            entity.Property(e => e.ArticleNumber).IsRequired().HasMaxLength(50);
            entity.HasIndex(e => e.ArticleNumber).IsUnique();
            entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
        });

        modelBuilder.Entity<StorageMovement>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Type).IsRequired();
            entity.Property(e => e.Quantity).IsRequired();
            entity.HasOne(e => e.StorageItem)
                .WithMany(e => e.Movements)
                .HasForeignKey(e => e.StorageItemId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
