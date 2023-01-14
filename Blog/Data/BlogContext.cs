using Blog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    public class BlogContext : DbContext
    {
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Comment> Like { get; set; }
        public DbSet<Comment> Tag { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Writer> Writers { get; set; }

        public BlogContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // do pk on bridge tables
            modelBuilder.Entity<Comment>().HasKey(a => new { a.UserId, a.BlogPostId });
            modelBuilder.Entity<Tag>().HasKey(tagObj => new { tagObj.BlogPostId, tagObj.CategoryId });
            modelBuilder.Entity<Like>().HasKey(likeObj => new { likeObj.UserId, likeObj.BlogPostId });
            // somehow set fk on these tables :crycatto:
            modelBuilder.Entity<Category>().HasMany(cat => cat.Tags).WithOne(tag => tag.Category)
                .HasForeignKey(tag => tag.CategoryId);

            modelBuilder.Entity<BlogPost>().HasMany(cat => cat.Comments).WithOne(tag => tag.BlogPost)
                .HasForeignKey(tag => tag.BlogPostId);
            modelBuilder.Entity<BlogPost>().HasMany(cat => cat.Likes).WithOne(tag => tag.BlogPost)
                .HasForeignKey(tag => tag.BlogPostId);

            modelBuilder.Entity<User>()
                .HasMany(writer => writer.Likes)
                .WithOne(a => a.User).HasForeignKey(a => a.UserId);
            modelBuilder.Entity<User>()
                .HasMany(writer => writer.Comments)
                .WithOne(a => a.User).HasForeignKey(a => a.UserId);

            // do rest 
            modelBuilder.Entity<User>()
                .HasOne(writer => writer.Writer)
                .WithOne(a => a.User).HasForeignKey<Writer>(a => a.UserId);

            modelBuilder.Entity<BlogPost>().HasOne(cat => cat.Writer).WithMany(tag => tag.BlogPosts);

            base.OnModelCreating(modelBuilder);
        }
    }
}