using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using BullySquasher.DTOs;
using BullySquasher.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BullySquasher.Controllers.API
{
    public class ChildController : ApiController
    {
        private ApplicationDbContext db;
        private UserManager<ApplicationUser> UserManager;

        public ChildController()
        {
            db = new ApplicationDbContext();
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }

        // GET /api/child/id
        public ChildDto GetChild(int id)
        {
            var val = db.Children.Find(id);

            if (val == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Child, ChildDto>(val);
        }

        // GET /api/child/parentId
        public IEnumerable<ChildDto> GetChildren(string parentId)
        {
            var val = 
                db.Children
                .Where(c => c.ParentId == parentId)
                .ToList()
                .Select(Mapper.Map<Child, ChildDto>);
            return val;
        }

        // POST /api/child
        [HttpPost]
        public ChildDto CreateChild(ChildSaveDto childDto)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var child = Mapper.Map<ChildSaveDto, Child>(childDto);

            //UserManager.FindById(child.ParentId);
            if(db.Parents.Find(child.ParentId) == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            child.DateCreated = DateTime.UtcNow;
            child.DateModified = child.DateCreated;
            db.Children.Add(child);
            db.SaveChanges();
            childDto.Id = child.Id;
            return Mapper.Map<Child, ChildDto>(child);
        }

        // PUT /api/child/id
        [HttpPut]
        public void UpdateChild(int id, ChildSaveDto childSaveDto)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var val = db.Children.SingleOrDefault(c => c.Id == id);

            if(val == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<ChildSaveDto, Child>(childSaveDto, val);
            val.Name = childSaveDto.Name;
            val.ParentId = childSaveDto.ParentId;
            val.DateModified = DateTime.UtcNow;

            db.SaveChanges();
        }

        // DELETE /api/child/id
        [HttpDelete]
        public void DeleteChild(int id)
        {
            var val = db.Children.SingleOrDefault(c => c.Id == id);

            if(val == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            val.DateDeleted = DateTime.UtcNow;
            db.SaveChanges();
        }
    }
}
