using System;
using System.Linq;
using BlogEFFluentMapping.Data;

namespace BlogEFFluentMapping
{
    class Program
    {
        static void Main(string[] args)
        {
            /*

            AsNoTracking - Use it when the data will not be modified and sent to the database again
            Use -> Async and Await - Task result 
            Use Eager Loading (Include) instead of Lazy Loading (virtual)
            Use pagination (Skip, Take)
            Avoid ThenInclude (subselect) if possible
            Consuming (Pure queries and Views) as example on PostWithTagsCount

            */

            using var ctx = new BlogDataContext();
            var posts = ctx.PostWithTagsCount.ToList();
            foreach (var post in posts)
                Console.WriteLine($"{post.Name} - Count: {post.Count}");
        }
    }
}
