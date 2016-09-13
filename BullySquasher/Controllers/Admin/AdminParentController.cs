using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BullySquasher.Models;

namespace BullySquasher.Controllers
{
    public class AdminParentController : Controller
    {
        private ApplicationDbContext _context;

        public AdminParentController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var parents = _context.Parents.ToList();
            
            return View(parents);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}