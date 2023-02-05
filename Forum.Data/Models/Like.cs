namespace Forum.Data.Models
{
    public class Like
    {
        public int Id { get; set; }
        public bool IsPositive { get; set; }
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
        public int ReplyId { get; set; }
        public Reply Reply { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
