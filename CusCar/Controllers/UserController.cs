using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CusCar.Models;


namespace CusCar.Controllers
{
    public class UserController : ApiController
    {
        private EFContext db = new EFContext();
        
        //GET api/<controller>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return db.Users.AsEnumerable();
        }

        //GET api/<controller>/5
        public User Get(int id)
        {
            User User = db.Users.Find(id);

            if (User == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return User;
        }

        //POST api/<controller>
        public HttpResponseMessage Post([FromBody] User User)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(User);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, User);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new {id = User.UserId}));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        //PUT api/<controller>/5
        public HttpResponseMessage Put([FromBody] User User)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                db.SaveChanges();
            }
            catch(DbUpdateConcurrencyException ex) {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        //DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            User User = db.Users.Find(id);

            if (User == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Users.Remove(User);

            try {
                db.SaveChanges();
            }
            catch(DbUpdateConcurrencyException ex){
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, User);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
	}
}