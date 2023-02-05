using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Forum.Data.Models
{
    public class User : IdentityUser
    {
        public virtual ICollection<Topic> Topics { get; set; } = new HashSet<Topic>();
        public virtual ICollection<Reply> Replies { get; set; } = new HashSet<Reply>();
        public virtual ICollection<Like> Likes { get; set; } = new HashSet<Like>();
        public virtual ICollection<Award> Awards { get; set; } = new HashSet<Award>();
    }
}
