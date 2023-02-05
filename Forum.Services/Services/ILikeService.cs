using System.Threading.Tasks;

namespace Forum.Services.Services
{
    public interface ILikeService
    {
        Task LikeTopic(int topicId, string authorId);
        Task DislikeTopic(int topicId, string authorId);
    }
}
