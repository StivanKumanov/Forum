using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    public class LikeController : Controller
    {
        // GET: LikeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: LikeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LikeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LikeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LikeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LikeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LikeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LikeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
