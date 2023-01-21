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
        public DbSet<Like> Likes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Writer> Writers { get; set; }

        public BlogContext(DbContextOptions options) : base(options){}

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
                .HasForeignKey(tag => tag.BlogPostId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<BlogPost>().HasMany(cat => cat.Likes).WithOne(tag => tag.BlogPost)
                .HasForeignKey(tag => tag.BlogPostId).OnDelete(DeleteBehavior.NoAction);;

            modelBuilder.Entity<AppUser>()
                .HasMany(writer => writer.Likes)
                .WithOne(a => a.AppUser).HasForeignKey(a => a.UserId);
            modelBuilder.Entity<AppUser>()
                .HasMany(writer => writer.Comments)
                .WithOne(a => a.AppUser).HasForeignKey(a => a.UserId);

            // do rest 
            modelBuilder.Entity<AppUser>()
                .HasOne(writer => writer.Writer)
                .WithOne(a => a.AppUser).HasForeignKey<Writer>(a => a.UserId);

            modelBuilder.Entity<Writer>().HasMany(cat => cat.BlogPosts).WithOne(tag => tag.Writer)
            .HasForeignKey(a=>a.WriterId);
            base.OnModelCreating(modelBuilder);
        }
    }
}