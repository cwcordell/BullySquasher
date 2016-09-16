using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using BullySquasher.Models;
using Microsoft.AspNet.Identity;

namespace BullySquasher.Controllers.API
{
    public class ParentController : ApiController
    {
        private ApplicationDbContext db;
        public ParentController()
        {
            db = new ApplicationDbContext();
        }

        // GET /api/parent/id
        public Parent GetParent(string id)
        {
            var parent = db.Parents.Find(User.Identity.GetUserId());

            if(parent == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return parent;
        }
    }
}
