using Forum.Data.Models;
using Forum.Models.Replies;
using Forum.Models.Topics;
using Forum.Services.Services;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Forum.Controllers
{
    public class TopicsController : Controller
    {
        private readonly ITopicService _topicService;

        public TopicsController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        // GET: Topics
        public async Task<IActionResult> Index()
        {
            var topics = await _topicService.GetAll();
            return View(topics);
        }

        // GET: Topics/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var topic = await _topicService.GetDetails(id);
            topic.IsCreator = topic.AuthorId == this.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return View(topic);
        }

        // GET: Topics/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: Topics/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TopicViewModel topicViewModel)
        {
            try
            {
                var authorId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                await _topicService.Create(topicViewModel.Title, topicViewModel.Content, authorId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Topics/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var topic = await _topicService.GetTopicById(id);
            return View(topic);
        }

        // POST: Topics/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Topic topic)
        {
            try
            {
                await _topicService.Edit(topic.Id, topic.Title, topic.Content);
                return RedirectToAction(nameof(Details), new {Id = topic.Id});
            }
            catch
            {
                return View();
            }
        }

        // GET: Topics/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            await _topicService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
      
    }
}
