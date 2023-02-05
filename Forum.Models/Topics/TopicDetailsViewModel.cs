using Forum.Models.Replies;
using System.Collections.Generic;

namespace Forum.Models.Topics
{
    public class TopicDetailsViewModel : TopicViewModel
    {
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public string AuthorId { get; set; }
        public bool IsCreator { get; set; }

        public IEnumerable<ReplyViewModel> Replies { get; set; }
    }
}
