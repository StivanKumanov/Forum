using Forum.Data.Models.Enums;

namespace Forum.Data.Models
{
    public class Award
    {
        public int Id { get; set; }
        public AwardType Type { get; set; }
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
