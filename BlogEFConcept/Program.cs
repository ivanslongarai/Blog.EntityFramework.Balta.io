using System;
using System.Linq;
using BlogEF.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogEF
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new Data.BlogDataContext())
            {
                // --- Inserting tag ---
                // var tag = new Tag { Name = "ASP.NET", Slug = "aspnet" };
                // ctx.Tags.Add (tag);
                // ctx.SaveChanges();
                //
                //
                //
                // ---- Editing tag ---
                // var tag = ctx.Tags.FirstOrDefault(t => t.Id == 1);
                // tag.Name = ".NET";
                // tag.Slug = "dotnet";
                // ctx.Tags.Update (tag);
                // ctx.SaveChanges();
                //
                //
                //
                // ---- Deleting tag ---
                // var tag = ctx.Tags.FirstOrDefault(t => t.Id == 1);
                // ctx.Tags.Remove (tag);
                // ctx.SaveChanges();
                //
                //
                //
                // ---- Listing tags ---
                // var tags =
                //     ctx
                //         .Tags
                //         .AsNoTracking()
                //         .Where(t => t.Name.Contains("ASP"))
                //         .ToList();
                // ToList() executes the query, it should be always at the end
                // To just list the information use AsNoTracking() for getting more performance
                // If want to call an update or a delete after, don't use AsNoTracking()
                // foreach (var tag in tags)
                // {
                //     Console.WriteLine($"{tag.Id} - {tag.Name} - {tag.Slug}");
                // }
                //
                //
                //
                // ---- Listing a tag ---
                var tag =
                    ctx.Tags.AsNoTracking().FirstOrDefault(t => t.Id == 4);
                Console.WriteLine($"{tag?.Id} - {tag?.Name} - {tag?.Slug}");
                // FirstOrDefault gets the first, SingleOrDefault in case of more than one occurrence it creates an exception
            }
        }
    }
}
