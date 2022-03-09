using System;
using System.Linq;
using BlogEF.Models;
using Microsoft.EntityFrameworkCore;

// ---> EF Mapping types <---
//Data Annotations Mapping
namespace BlogEF
{
    class Program
    {
        static void Main(string[] args)
        {
            using var ctx = new Data.BlogDataContext();
            Updating(ctx);
        }

        public static void InsertPost(Data.BlogDataContext ctx){
            var user = new User
            {
                Name = "ivan Longarai",
                Slug = "ivanlongarai",
                Email = "ivan@gmail.com",
                Bio = "programmer",
                Image = "https://google.com",
                PasswordHash = "123456789"
            };

            var category = new Category
            {
                Name = "backend",
                Slug = "backend"
            };

            var post = new Post
            {
                Author = user,
                Title = "My new post",
                Category = category,
                Summary = "summary",
                Body = "<p>Hello World</p>",
                Slug = "starting-with-EF-Core",
                CreateDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
            };

            ctx.Posts.Add(post);
            ctx.SaveChanges();
        }

        public static void GetPosts(Data.BlogDataContext ctx){
            var posts = ctx
                .Posts
                .AsNoTracking() //If not persist the data after gets it
                .Include(a => a.Author) //Brings Author information using an INNER JOIN on User table
                    // .ThenInclude() - to continue including ... (SubSelect)
                .Include(x => x.Category)
                .Where(x => x.AuthorId == 3)
                .OrderByDescending(p => p.LastUpdateDate)
                .ToList();

            foreach (var post in posts)
                Console.WriteLine($"Post: {post.Title} Writen by: {post.Author?.Name} in {post.Category?.Name}");
        }


        public static void Updating(Data.BlogDataContext ctx){
            var post = ctx.Posts
                .Include(x => x.Author)
                .Include(x => x.Category)
                .OrderByDescending(x => x.LastUpdateDate)
                .FirstOrDefault();
            post.Author.Name = "Ivan Longarai";
            post.Category.Name = "Backend";
            post.Title = ".NET Post";
            post.LastUpdateDate = DateTime.Now;
            ctx.Posts.Update(post);
            ctx.SaveChanges();
        }


    }
}
