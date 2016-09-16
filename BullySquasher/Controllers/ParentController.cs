using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
        private int recordLimit { get; set; }

        public ParentController()
        {
            _context = new ApplicationDbContext();
            recordLimit = 6;
        }

        public int RecordLimit
        {
            get { return recordLimit; }
            set { recordLimit = value; }
        }

        public ActionResult Index()
        {
            Parent parent = getOrSetParent();

            parent.Children = (from c in _context.Children where c.ParentId == parent.Id select c).ToList();

            foreach (var child in parent.Children)
            {
                child.ChildDevices = (from d in _context.ChildDevices
                    where d.ChildId == child.Id
//                    join t in _context.DeviceTypes on d.DeviceType.Id equals t.Id
                    select d).ToList() ?? new List<ChildDevice>();

                foreach (var device in child.ChildDevices)
                {
                    device.DeviceType = (
                        from t in _context.DeviceTypes
                        where device.DeviceTypeId == t.Id
                        select t
                        ).Single();
                    
                    device.ChildMessagesList = (
                        from m in _context.ChildMessages
                         where m.ChildDeviceId == device.Id
                         select m
                         ).Take(recordLimit).ToList() ?? new List<ChildMessage>();
                }
            }
        

        return View(parent);
        }

        private Parent getOrSetParent()
        {
            var userId = User.Identity.GetUserId();
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
            return parent;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

    }
}