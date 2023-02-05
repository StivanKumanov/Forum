using Forum.Data.Models;
using Forum.Models.Replies;
using Forum.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Services.Services
{
    public class ReplyService : IReplyService
    {
        private readonly IRepository<Reply> _replyRepo;
        public ReplyService(IRepository<Reply> replyRepo)
        {
            _replyRepo = replyRepo;
        }
        public async Task Create(string authorId, int topicId, string content)
        {
            var reply = new Reply
            {
                AuthorId = authorId,
                TopicId = topicId,
                Content = content,
            };
            await _replyRepo.AddAsync(reply);
            await _replyRepo.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _replyRepo.All().FirstOrDefaultAsync(x => x.Id == id);
            _replyRepo.Delete(entity);
            await _replyRepo.SaveChangesAsync();
        }

        public async Task Edit(string authorId, int topicId, string content)
        {
            var reply = _replyRepo.All().FirstOrDefault(x => x.Id == topicId);
            reply.Content = content;
            _replyRepo.Update(reply);
            await _replyRepo.SaveChangesAsync();
        }

        public async Task<Reply> GetReply(int id)
        {
            return await _replyRepo.AllAsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
