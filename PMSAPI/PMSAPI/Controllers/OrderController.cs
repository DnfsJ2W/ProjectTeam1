using PMSDAL.Models;
using PMSDAL.Models.Viewmodel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace PMSAPI.Controllers
{
    public class OrderController : ApiController
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        //db.Configuration.ProxyCreationEnabled = false;
        // GET: api/Orders
        public List<OrderViewModel> GetOrders()

        {
       
            //IQueryable<tblOrder> obj = null;
            List<OrderViewModel> listview = new List<OrderViewModel>();


            var obj = from d in db.Orders
                       join c in db.ProductOrder on d.OrderId equals c.OrderId
                       join s in db.Tracking on c.OrderId equals s.OrderId
                      select new OrderViewModel
                      {
                          OrderId = d.OrderId,
                          Quantity = d.Quantity,
                          OrderDate = d.OrderDate,
                          UserName = d.User.UserName,
                          ProductName= c.Product.ProductName,
                          Price=c.Product.Price,
                          EstimatedDate=s.EstimatedDate
                      };
            foreach (var i in obj)
            {
                //OrderViewModel data = new OrderViewModel() {OrderId=i. }
               
                listview.Add(i);
            }
            // other assignments
            return listview;






            ////var count = CurrentDbContext.PaymentTypes.Count();

        }
        // GET: api/Orders/5
        [ResponseType(typeof(tblOrder))]
        public IHttpActionResult GetOrderById(int id)
        {
            
            tblOrder tblOrder = db.Orders.Find(id);
            if (tblOrder == null)
            {
                return NotFound();
            }

            return Ok(tblOrder);
        }

        // PUT: api/Orders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblOrder(int id, tblOrder tblOrder)
        {
            db.Configuration.ProxyCreationEnabled = false;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblOrder.OrderId)
            {
                return BadRequest();
            }

            db.Entry(tblOrder).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblOrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Orders
        [ResponseType(typeof(tblOrder))]
        public IHttpActionResult PosttblOrder(tblOrder tblOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Orders.Add(tblOrder);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblOrder.OrderId }, tblOrder);
        }

        // DELETE: api/Orders/5
        [ResponseType(typeof(tblOrder))]
        public IHttpActionResult DeletetblOrder(int id)
        {
            
            tblOrder tblOrder = db.Orders.Find(id);
            if (tblOrder == null)
            {
                return NotFound();
            }

            db.Orders.Remove(tblOrder);
            db.SaveChanges();

            return Ok(tblOrder);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblOrderExists(int id)
        {
            return db.Orders.Count(e => e.OrderId == id) > 0;
        }
    }
}
