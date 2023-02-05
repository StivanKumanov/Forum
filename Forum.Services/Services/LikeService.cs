using Forum.Data.Models;
using Forum.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Services.Services
{
    public class LikeService : ILikeService
    {
        private readonly IRepository<Topic> _topicRepository;

        public LikeService(IRepository<Topic> topicRepository)
        {
            _topicRepository = topicRepository;
        }
        public async Task DislikeTopic(int topicId, string authorId)
        {
            var topic = await _topicRepository.All().FirstOrDefaultAsync(x => x.Id == topicId);
            if (topic.Likes.ToList().Any(x => x.UserId == authorId || !x.IsPositive))
            {
                return;
            }
            var like = new Like() { IsPositive = false, TopicId = topicId };
            topic.Likes.Add(like);
            await _topicRepository.SaveChangesAsync();
        }

        public async Task LikeTopic(int topicId, string authorId)
        {
            var topic = await _topicRepository.All().FirstOrDefaultAsync(x => x.Id== topicId);
            if (topic.Likes.ToList().Any(x => x.UserId == authorId || x.IsPositive))
            {
                return;
            }
            var like = new Like() { IsPositive = true, TopicId = topicId };
            topic.Likes.Add(like);
            await _topicRepository.SaveChangesAsync();
        }
    }
}
