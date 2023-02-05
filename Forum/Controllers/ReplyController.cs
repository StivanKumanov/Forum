using Forum.Models.Replies;
using Forum.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Forum.Controllers
{
    public class ReplyController : Controller
    {
        private readonly IReplyService _replyService;
        public ReplyController(IReplyService replyService)
        {
            _replyService = replyService;
        }
        // GET: ReplyController
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: ReplyController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View();
        }

        // GET: ReplyController/Create
        public async Task<IActionResult> Create(int topicId, string authorId)
        {
            var viewModel = new ReplyViewModel { AuthorId = authorId, TopicId = topicId };
            return View(viewModel);
        }

        // POST: ReplyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReplyViewModel replyViewModel)
        {
            try
            {
                await _replyService.Create(replyViewModel.AuthorId, replyViewModel.TopicId, replyViewModel.Content);

                return Redirect($"/topics/details/{replyViewModel.TopicId}");
            }
            catch
            {
                return View();
            }
        }

        // GET: ReplyController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }

        // POST: ReplyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ReplyViewModel replyViewModel)
        {
            try
            {
                await _replyService.Edit(replyViewModel.AuthorId, replyViewModel.Id, replyViewModel.Content);

                return Redirect($"/topics/details/{replyViewModel.TopicId}");
            }
            catch
            {
                return View();
            }
        }

        // GET: ReplyController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            await _replyService.Delete(id);

            return Redirect($"/topics/details/{id}");
        }

    }
}
