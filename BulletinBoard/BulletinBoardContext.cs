using BulletinBoard.Entities;
using Microsoft.EntityFrameworkCore;

namespace BulletinBoard;

public class BulletinBoardContext : DbContext
{
    public virtual DbSet<Post> Post { get; set; } = null!;
    
    public BulletinBoardContext()
    {
    }

    public BulletinBoardContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Post>(entity =>
        {
            entity.ToTable("post");

            entity.HasComment("貼文");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasComment("流水編號");

            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title")
                .HasComment("標題");

            entity.Property(e => e.Content)
                .HasColumnType("text")
                .HasColumnName("content")
                .HasComment("內文");
        });
    }
}
