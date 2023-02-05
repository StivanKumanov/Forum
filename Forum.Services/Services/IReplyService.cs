using Forum.Data.Models;
using System.Threading.Tasks;

namespace Forum.Services.Services
{
    public interface IReplyService
    {
        Task Create(string authorId, int topicId, string content);
        Task Edit(string authorId, int topicId, string content);
        Task Delete(int id);
        Task<Reply> GetReply(int id); 
    }
}
