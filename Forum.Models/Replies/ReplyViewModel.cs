namespace Forum.Models.Replies
{
    public class ReplyViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string AuthorId { get; set; }
        public int TopicId { get; set; }
    }
}
