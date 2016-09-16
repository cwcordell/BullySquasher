using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BullySquasher.Models;

namespace BullySquasher.Controllers
{
    [Authorize]
    public class ChildMessageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ChildMessage
        public ActionResult Index()
        {
            var messages = db.ChildMessages.Include(d => d.ChildDevice).ToList();
            return View(messages);
        }

        // POST: Child/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
        public ActionResult ChangeIsBullyMessage(int id)
        {
            var message = db.ChildMessages.Find(id);

            if (message != null)
            {
                message.IsBullyMessage = !message.IsBullyMessage;
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Parent");
        }
    }
}