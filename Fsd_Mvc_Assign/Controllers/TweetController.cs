using System.Web.Mvc;

namespace Fsd_Mvc_Assign.Controllers
{
    public class TweetController : Controller
    {
        // GET: Tweet
        public ActionResult Index()
        {
            return View();
        }

        // GET: Tweet/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tweet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tweet/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tweet/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tweet/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tweet/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tweet/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
