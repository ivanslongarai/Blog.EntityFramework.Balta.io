using System.ComponentModel.DataAnnotations;

namespace BlogEFFluentMapping.Models
{
    public class PostWithTagsCount
    {
        [Key]
        public string Name { get; set; }

        public int Count { get; set; }
    }
}
