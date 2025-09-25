using Microsoft.EntityFrameworkCore;
using SocialMedia.Models;

namespace SocialMedia.Data
{
    public class SocialMediaDbContext : DbContext
    {
        public SocialMediaDbContext(DbContextOptions options) : base(options){}

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Like> Likes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Post>()
                .HasOne(p => p.CreatedBy)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.CommentedBy)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.CommentedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reaction>()
                .HasOne(r => r.Comment)
                .WithMany(c => c.Reactions)
                .HasForeignKey(r => r.CommentId);

            modelBuilder.Entity<Like>()
                .HasOne(l => l.Post)
                .WithMany(p => p.Likes)
                .HasForeignKey(l => l.PostId);

            modelBuilder.Entity<Like>()
                .HasOne(l => l.User)
                .WithMany(u => u.Likes)
                .HasForeignKey(l => l.UserId);


            modelBuilder.Entity<Post>().HasIndex(p => p.CreatedById);
            modelBuilder.Entity<Comment>().HasIndex(c => new { c.PostId, c.CommentedById });
            modelBuilder.Entity<Reaction>().HasIndex(r => r.CommentId);
            modelBuilder.Entity<Like>().HasIndex(l => new { l.PostId, l.UserId });
        }
    }
}
