using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BullySquasher.Models;
using Microsoft.AspNet.Identity;

namespace BullySquasher.Controllers
{
    [Authorize]
    public class ChildController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Child
        public ActionResult Index()
        {
            var children = db.Children.Include(c => c.Parent).Where(c => c.DateDeleted == null);
            return View(children.ToList());
        }

        // GET: Child/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Child child = db.Children.Include(c => c.Parent).Where(c => c.DateDeleted == null).SingleOrDefault(c => c.Id == id);
            if (child == null)
            {
                return HttpNotFound();
            }
            return View(child);
        }

        // GET: Child/Create
        public ActionResult Create()
        {
            return View(new Child { ParentId = User.Identity.GetUserId()});
        }

        // POST: Child/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, ParentId")] Child child)
        {
            
//            child.ParentId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                child.DateCreated = DateTime.UtcNow;
                child.DateModified = child.DateCreated;
                db.Children.Add(child);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(child);
        }

        // GET: Child/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Child child = db.Children.Include(c => c.Parent).Where(c => c.DateDeleted == null).SingleOrDefault(c => c.Id == id);
            if (child == null)
            {
                return HttpNotFound();
            }
            
            return View(child);
        }

        // POST: Child/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Name, ParentId, DateCreated")] Child child)
        {
            if (ModelState.IsValid)
            {
                child.DateModified = DateTime.UtcNow;
                db.Entry(child).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParentId = new SelectList(db.Parents, "Id", "Id", child.ParentId);
            return View(child);
        }

        // GET: Child/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Child child = db.Children.Include(c => c.Parent).Where(c => c.DateDeleted == null).SingleOrDefault(c => c.Id == id);
            if (child == null)
            {
                return HttpNotFound();
            }
            return View(child);
        }

        // POST: Child/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Child child = db.Children.Include(c => c.Parent).Where(c => c.DateDeleted == null).SingleOrDefault(c => c.Id == id);
            child.DateDeleted = DateTime.UtcNow;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
