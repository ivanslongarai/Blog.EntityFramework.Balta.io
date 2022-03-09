using System;
using System.Linq;
// ---> EF Mapping types <---
//Fluent Mapping
using BlogEFFluentMapping.Data;
using BlogEFFluentMapping.Models;

namespace BlogEFFluentMapping
{
    class Program
    {
        static void Main(string[] args)
        {

            using var ctx = new BlogDataContext();

            InsertUser(ctx);
            InserPost(ctx);

        }        

        public static void InsertUser(BlogDataContext ctx){
            ctx.Users.Add(new User
            {
                Bio = "Programmer",
                Email = "ivan2@gmail.com",
                Image = "www.google.com",
                Name = "Ivan",
                PasswordHash = "123",
                Slug = "ivan."
            });

            ctx.SaveChanges();
        }

        public static void InserPost(BlogDataContext ctx) {

            var user = ctx.Users.FirstOrDefault();

            var category = new Category()
            {
                Name = "CCtegory",
                Slug = "cctegory"
            };

            var post = new Post()
            {
                Author = user,
                Body = "My post",
                Category = category,
                CreateDate = DateTime.Now,
                //LastUpdateDate = DateTime.Now,
                Slug = "my-post",
                Summary = "In this post we are going to ....",
                //Tags = null,
                Title = "May post"
            };

            ctx.Posts.Add(post);
            ctx.SaveChanges();
        }

    }
}
