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
    public class ProductOrderPaymentsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: api/ProductOrderPayments
        public List<Productorderpayment> GetProductOrderPayment()
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Productorderpayment> productview = new List<Productorderpayment>();


            var obj = from d in db.ProductOrderPayment
                      join c in db.Payments on d.PaymentId equals c.PaymentId

                      select new Productorderpayment
                      {
                          ProductOrderPaymentId = d.ProductOrderPaymentId,
                          ProductOrderId = d.ProductOrderId,
                          Payment = d.Payment,
                          BankName = d.BankName,
                          CardNumber = d.CardNumber,
                          NameOnCard = d.NameOnCard,
                          ExpiryDate = d.ExpiryDate,
                          UserId = d.UserId
                      };
            foreach (var i in obj)
            {
                //OrderViewModel data = new OrderViewModel() {OrderId=i. }

                productview.Add(i);
            }
            // other assignments
            return productview;
           // return db.ProductOrderPayment;
        }

        // GET: api/ProductOrderPayments/5
        [ResponseType(typeof(tblProductOrderPayment))]
        public IHttpActionResult GettblProductOrderPayment(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            tblProductOrderPayment tblProductOrderPayment = db.ProductOrderPayment.Find(id);
            if (tblProductOrderPayment == null)
            {
                return NotFound();
            }

            return Ok(tblProductOrderPayment);
        }

        // PUT: api/ProductOrderPayments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblProductOrderPayment(int id, tblProductOrderPayment tblProductOrderPayment)
        {
            db.Configuration.ProxyCreationEnabled = false;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblProductOrderPayment.ProductOrderPaymentId)
            {
                return BadRequest();
            }

            db.Entry(tblProductOrderPayment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblProductOrderPaymentExists(id))
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

        // POST: api/ProductOrderPayments
        [ResponseType(typeof(tblProductOrderPayment))]
        public IHttpActionResult PosttblProductOrderPayment(tblProductOrderPayment tblProductOrderPayment)
        {
            db.Configuration.ProxyCreationEnabled = false;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductOrderPayment.Add(tblProductOrderPayment);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblProductOrderPayment.ProductOrderPaymentId }, tblProductOrderPayment);
        }

        // DELETE: api/ProductOrderPayments/5
        [ResponseType(typeof(tblProductOrderPayment))]
        public IHttpActionResult DeletetblProductOrderPayment(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            tblProductOrderPayment tblProductOrderPayment = db.ProductOrderPayment.Find(id);
            if (tblProductOrderPayment == null)
            {
                return NotFound();
            }

            db.ProductOrderPayment.Remove(tblProductOrderPayment);
            db.SaveChanges();

            return Ok(tblProductOrderPayment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblProductOrderPaymentExists(int id)
        {
            return db.ProductOrderPayment.Count(e => e.ProductOrderPaymentId == id) > 0;
        }
    }
}