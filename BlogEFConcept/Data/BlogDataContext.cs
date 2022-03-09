using BlogEF.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogEF.Data
{
    public class BlogDataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Post> Posts { get; set; }

        //public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<User> Users { get; set; }

        //public DbSet<UserRole> UserRoles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder opt) =>
            opt
                .UseSqlServer(@"Data Source=desktop-vf2hide\sqlexpress;Initial Catalog=blogef;Integrated Security=True;Connect Timeout=30");
    }
}
