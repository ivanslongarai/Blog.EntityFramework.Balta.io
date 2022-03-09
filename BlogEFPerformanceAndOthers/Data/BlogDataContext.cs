using BlogEFFluentMapping.Data.Mappings;
using BlogEFFluentMapping.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogEFFluentMapping.Data
{
    public class BlogDataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<PostWithTagsCount> PostWithTagsCount { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder opt)
        {
            opt
                .UseSqlServer(@"Data Source=desktop-vf2hide\sqlexpress;Initial Catalog=fluentblogef;Integrated Security=True;Connect Timeout=30");
            // opt.LogTo(Console.WriteLine); // Shows queries information on Console
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new PostMap());

            modelBuilder
                .Entity<PostWithTagsCount>(x =>
                {
                    x
                        .ToSqlQuery(@"                   
                        SELECT P.[Title] AS [Name], Count(COALESCE(PT.PostId, 0)) AS [Count] FROM [Post] P
                        LEFT JOIN [PostTag] PT ON PT.PostId = P.Id
                        GROUP BY P.[Title]
                    ");
                });
        }
    }
}
