using System;
using System.Collections.Generic;

namespace Forum.Data.Models
{
    public class Topic
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string  Content { get; set; }
        public int AuthorId { get; set; }
        public User Author { get; set; }
        public virtual ICollection<Like> Likes { get; set; } = new HashSet<Like>();
        public virtual ICollection<Reply> Replies { get; set; } = new HashSet<Reply>();
        public virtual ICollection<Award> Awards { get; set; } = new HashSet<Award>();
    }
}
