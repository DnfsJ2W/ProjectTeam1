using PMSDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PMSAPI.Controllers
{
    public class CategoriesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Categories
        public IEnumerable<tblCategory> Get()
        {
            return db.Categories.ToList();
        }

        // GET: api/Categories/5
        public HttpResponseMessage Get(int id)
        {
            var detail = (from a in db.Categories where a.CategoryId == id select a).FirstOrDefault();

            if (detail != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, detail);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Category Not Found");
            }
        }

        // POST: api/Categories
        public HttpResponseMessage Post([FromBody] tblCategory category)
        {
            try
            {
                db.Categories.Add(category);
                db.SaveChanges();

                var msg = Request.CreateResponse(HttpStatusCode.Created, category);
                msg.Headers.Location = new Uri(Request.RequestUri + category.CategoryId.ToString());

                return msg;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT: api/Categories/5
        public HttpResponseMessage Put(int id, [FromBody] tblCategory category)
        {
            var detail = (from a in db.Categories where a.CategoryId == id select a).FirstOrDefault();

            if (detail != null)
            {
                detail.CategoryId = category.CategoryId;
                detail.CategoryName = category.CategoryName;

                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, detail);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Category Not Found");
            }
        }

        // DELETE: api/Categories/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var _DeleteMember = (from a in db.Categories where a.CategoryId == id select a).FirstOrDefault();

                if (_DeleteMember != null)
                {
                    db.Categories.Remove(_DeleteMember);
                    db.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK, id);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Category Not Found or Invalid " + id.ToString());
                }
            }

            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
