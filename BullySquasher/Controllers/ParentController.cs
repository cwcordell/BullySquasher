using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BullySquasher.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.ApplicationInsights.Web;
using Microsoft.AspNet.Identity;

namespace BullySquasher.Controllers
{
    [Authorize]
    public class ParentController : Controller
    {
        private ApplicationDbContext _context;

        public ParentController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            Child child = new Child();
            var userId = User.Identity.GetUserId();
            child.ParentId = userId;
            child.Name = "Harry Cox";
            child.DateCreated = DateTime.UtcNow;
            child.DateModified = child.DateCreated;
            _context.Children.Add(child);
            Parent parent = _context.Parents.SingleOrDefault(p => p.Id == userId);
            if (parent == null)
            {
                parent = new Parent();
                parent.Id = userId;
                parent.DateCreated = DateTime.UtcNow;
                parent.DateModified = parent.DateCreated;

                _context.Parents.Add(parent);
                _context.SaveChanges();
            }
            var temp2 = _context.Parents.Where(c => c.Id.Contains("77")).OrderBy(c => c.Id);

//            parent.Children = _context.Children.Include(d => d.ChildDevices).Select(d => d.ParentId == parent.Id);
            parent.Children = (from c in _context.Children where c.ParentId == parent.Id select c).ToList();

            return View(parent);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

    }
}