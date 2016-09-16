using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BullySquasher.Models;

namespace BullySquasher.Controllers
{
    [Authorize]
    public class ChildDevicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ChildDevices
        public ActionResult Index()
        {
            var childDevices = db.ChildDevices.Include(c => c.Child).Include(c => c.DeviceType).Where(c => c.DateDeleted == null);
            return View(childDevices.ToList());
        }

        // GET: ChildDevices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChildDevice childDevice = db.ChildDevices.Where(c => c.DateDeleted == null).SingleOrDefault(c => c.Id == id);
            if (childDevice == null)
            {
                return HttpNotFound();
            }
            return View(childDevice);
        }
        
        // GET: ChildDevices/Create
        public ActionResult Create(int? id)
        {
            ViewBag.ChildId = id != null ? new SelectList(db.Children, "Id", "Name", id) : new SelectList(db.Children, "Id", "Name");
            ViewBag.DeviceTypeId = new SelectList(db.DeviceTypes, "Id", "Name");
            return View();
        }

        // POST: ChildDevices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ChildId,DeviceTypeId")] ChildDevice childDevice)
        {
            if (ModelState.IsValid)
            {
                childDevice.DateCreated = DateTime.UtcNow;
                childDevice.DateModified = childDevice.DateCreated;
                db.ChildDevices.Add(childDevice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChildId = new SelectList(db.Children, "Id", "Name", childDevice.ChildId);
            ViewBag.DeviceTypeId = new SelectList(db.DeviceTypes, "Id", "Name", childDevice.DeviceTypeId);
            return View(childDevice);
        }

        // GET: ChildDevices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChildDevice childDevice = db.ChildDevices.Where(c => c.DateDeleted == null).SingleOrDefault(c => c.Id == id);
            if (childDevice == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChildId = new SelectList(db.Children, "Id", "Name", childDevice.ChildId);
            ViewBag.DeviceTypeId = new SelectList(db.DeviceTypes, "Id", "Name", childDevice.DeviceTypeId);
            return View(childDevice);
        }

        // POST: ChildDevices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ChildId,DeviceTypeId,DateCreated")] ChildDevice childDevice)
        {
            if (ModelState.IsValid)
            {
                childDevice.DateModified = DateTime.UtcNow;
                db.Entry(childDevice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChildId = new SelectList(db.Children, "Id", "Name", childDevice.ChildId);
            ViewBag.DeviceTypeId = new SelectList(db.DeviceTypes, "Id", "Name", childDevice.DeviceTypeId);
            return View(childDevice);
        }

        // GET: ChildDevices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChildDevice childDevice = db.ChildDevices.Find(id);
            if (childDevice == null)
            {
                return HttpNotFound();
            }
            return View(childDevice);
        }

        // POST: ChildDevices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChildDevice childDevice = db.ChildDevices.Where(c => c.DateDeleted == null).SingleOrDefault(c => c.Id == id);
            childDevice.DateDeleted = DateTime.UtcNow;
            db.ChildDevices.Remove(childDevice);
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
