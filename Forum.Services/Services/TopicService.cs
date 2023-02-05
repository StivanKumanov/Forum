using Forum.Data.Models;
using Forum.Models.Replies;
using Forum.Models.Topics;
using Forum.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Services.Services
{
    public class TopicService : ITopicService
    {
        private readonly IRepository<Topic> _topicRepo;
        private readonly IRepository<Reply> _replyRepo;
        public TopicService(IRepository<Topic> topicRepo, IRepository<Reply> replyRepo)
        {
            this._topicRepo = topicRepo;
            _replyRepo = replyRepo;
        }

        public async Task Create(string title, string content, string authorId)
        {
            var topic = new Topic
            {
                Title = title,
                Content = content,
                AuthorId = authorId
            };
            await _topicRepo.AddAsync(topic);
            await _topicRepo.SaveChangesAsync();

        }

        public async Task<IEnumerable<TopicViewModel>> GetAll()
        {
            return await _topicRepo.AllAsNoTracking()
                .Select(x => new TopicViewModel { Id = x.Id, Title = x.Title, Content = x.Content }).ToListAsync();
        }

        public async Task<TopicDetailsViewModel> GetDetails(int id)
        {
            return await _topicRepo.AllAsNoTracking().Where(x => x.Id == id).Select(x => new TopicDetailsViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                Likes = x.Likes.Count(l => l.IsPositive),
                Dislikes = x.Likes.Count(l => !l.IsPositive),
                Replies = x.Replies.Select(r => new ReplyViewModel {Id = r.Id, Content = r.Content }),
                AuthorId = x.AuthorId
            }).FirstOrDefaultAsync();
        }

        public async Task Edit(int id, string title, string content)
        {
            var topic = _topicRepo.All().FirstOrDefault(x => x.Id == id);
            topic.Title = title;
            topic.Content = content;
            _topicRepo.Update(topic);
            await _topicRepo.SaveChangesAsync();
        }

        public async Task<Topic> GetTopicById(int id)
        {
            return await _topicRepo.AllAsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Delete(int id)
        {
            var entity = await _topicRepo.All().FirstOrDefaultAsync(x => x.Id == id);
            _topicRepo.Delete(entity);
            foreach (var reply in entity.Replies)
            {
                _replyRepo.Delete(reply);
            }
            await _topicRepo.SaveChangesAsync();
        }
        public async Task<bool> IsUserCreator(int topicId, string authorId)
        {
            return await _topicRepo.AllAsNoTracking().AnyAsync(x => x.AuthorId == authorId && x.Id == topicId);
        }
    }
}
