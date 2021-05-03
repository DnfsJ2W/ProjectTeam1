using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PMSDAL.Models;
using PMSDAL.Models.Viewmodel;


namespace PMSAPI.Controllers
{
    public class ProductOrdersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ProductOrders
        public List<ProductOrderModel> GetProductOrder()
        {
            db.Configuration.ProxyCreationEnabled = false;

            List<ProductOrderModel> productview = new List<ProductOrderModel>();


            var obj = from d in db.ProductOrder
                      join c in db.Products on d.ProductId equals c.ProductId
                    
                      select new ProductOrderModel
                      {
                          ProductId = d.ProductId,
                          //OrderId = d.OrderId,
                          ProductOrderId = d.ProductOrderId,
                          ProductName = c.ProductImage,
                          ProductDescription = c.ProductDescription,
                          ProductImage = c.ProductImage,
                          //OrderDate = s.OrderDate,
                          StockStatus = c.StockStatus,
                         //Quantity=s.Quantity
                      };
            foreach (var i in obj)
            {
                //OrderViewModel data = new OrderViewModel() {OrderId=i. }

                productview.Add(i);
            }
            // other assignments
            return productview;

           // return db.ProductOrder;
        }

        // GET: api/ProductOrders/5
        [ResponseType(typeof(tblProductOrder))]
        public IHttpActionResult GettblProductOrder(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            tblProductOrder tblProductOrder = db.ProductOrder.Find(id);
            if (tblProductOrder == null)
            {
                return NotFound();
            }

            return Ok(tblProductOrder);
        }

        // PUT: api/ProductOrders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblProductOrder(int id, tblProductOrder tblProductOrder)
        {
            db.Configuration.ProxyCreationEnabled = false;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblProductOrder.ProductOrderId)
            {
                return BadRequest();
            }

            db.Entry(tblProductOrder).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblProductOrderExists(id))
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

        // POST: api/ProductOrders
        [ResponseType(typeof(tblProductOrder))]
        public IHttpActionResult PosttblProductOrder(tblProductOrder tblProductOrder)
        {
            db.Configuration.ProxyCreationEnabled = false;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductOrder.Add(tblProductOrder);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblProductOrder.ProductOrderId }, tblProductOrder);
        }

        // DELETE: api/ProductOrders/5
        [ResponseType(typeof(tblProductOrder))]
        public IHttpActionResult DeletetblProductOrder(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            tblProductOrder tblProductOrder = db.ProductOrder.Find(id);
            if (tblProductOrder == null)
            {
                return NotFound();
            }

            db.ProductOrder.Remove(tblProductOrder);
            db.SaveChanges();

            return Ok(tblProductOrder);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblProductOrderExists(int id)
        {
            return db.ProductOrder.Count(e => e.ProductOrderId == id) > 0;
        }
    }
}