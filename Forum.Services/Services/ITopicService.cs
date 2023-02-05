using Forum.Data.Models;
using Forum.Models.Topics;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace Forum.Services.Services
{
    public interface ITopicService
    {
        Task<TopicDetailsViewModel> GetDetails(int id);
        Task<IEnumerable<TopicViewModel>> GetAll();
        Task<Topic> GetTopicById(int id);
        Task Create(string title, string content, string authorId);
        Task Edit(int id, string title, string content);
        Task Delete(int id);
        Task<bool> IsUserCreator(int topicId, string authorId);
    }
}
