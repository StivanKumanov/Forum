using System.Collections.Generic;

namespace Forum.Data.Models
{
    public class Reply
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
        public int AuthorId { get; set; }
        public User Author { get; set; }
        public virtual ICollection<Like> Likes { get; set; } = new HashSet<Like>();
    }
}
