using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using PMSAPI.Models;

namespace PMSAPI.Controllers
{
    public class ProductsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        [HttpGet]
        [Route("api/GetProducts")]
        public IEnumerable<tblProduct> GetProduct()
        {
            IList<tblProduct> products = db.Products.ToList<tblProduct>();
            List<tblProduct> products1 = new List<tblProduct>();
            foreach (var p in products)
            {
                tblProduct List = new tblProduct()
                {
                    ProductId = p.ProductId,
                    ProductImage = p.ProductImage,
                    ProductName = p.ProductName,
                    ProductDescription =p.ProductDescription,
                  //  ProductOrderPayments = p.ProductOrderPayments,
                    ProductOrders = p.ProductOrders,
                    Quantity = p.Quantity,
                    Price = p.Price
                };

                products1.Add(List);
            }
            return products1;
        }
        [HttpGet]
        [Route("api/GetProduct/{id}")]
        public tblProduct GetProduct(int id)
        {
            tblProduct product = (from p in db.Products
                               where p.ProductId == id
                               select p).FirstOrDefault();
            tblProduct product1 = new tblProduct()
            {
                ProductId = product.ProductId,
                    ProductImage = product.ProductImage,
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                  //  ProductOrderPayments = product.ProductOrderPayments,
                    ProductOrders = product.ProductOrders,
                    Quantity = product.Quantity,
                    Price = product.Price
            };
            return product1;
        }




        [HttpPost]
        [Route("api/UploadImage")]
        [AllowAnonymous]
        public async Task<HttpResponseMessage> PostUserImage()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            try
            {
                tblProduct product = new tblProduct();
                var httpRequest = HttpContext.Current.Request;
               // product.ProductImage = httpRequest["PImage"];
                string PName = httpRequest["PName"];
                 product.ProductName = PName.Replace("\n", "");
                product.ProductDescription = httpRequest["Pdescription"];
                product.CategoryId = Convert.ToInt32(httpRequest["categoryId"]);
                product.Quantity = Convert.ToInt32(httpRequest["PQuantity"]);
                product.StockStatus = httpRequest["PStatus"];

                var provider = new MultipartMemoryStreamProvider();
                await Request.Content.ReadAsMultipartAsync(provider);
                foreach (string file in httpRequest.Files)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

                    var postedFile = httpRequest.Files[file];
                    if (postedFile != null && postedFile.ContentLength > 0)
                    {

                        int MaxContentLength = 1024 * 1024 * 1; //Size = 1 MB  

                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
                        var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();
                        if (!AllowedFileExtensions.Contains(extension))
                        {

                            var message = string.Format("Please Upload image of type .jpg,.gif,.png.");

                            dict.Add("error", message);
                            return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                        }
                        else if (postedFile.ContentLength > MaxContentLength)
                        {

                            var message = string.Format("Please Upload a file upto 1 mb.");

                            dict.Add("error", message);
                            return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                        }
                        else
                        {

                            Stream stream = postedFile.InputStream;
                            BinaryReader binaryReader = new BinaryReader(stream);
                            Byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                            var filePath = HttpContext.Current.Server.MapPath("~/ProductImages/" + postedFile.FileName + extension);

                                postedFile.SaveAs(filePath);
                                product.ProductImage = postedFile.FileName;
                                product.ImageByteCode = bytes;
                                product.Path = filePath;
                                db.Products.Add(product);
                                db.SaveChanges();

                        }
                    }

                    var message1 = string.Format("Image Updated Successfully.");
                    return Request.CreateErrorResponse(HttpStatusCode.Created, message1); ;
                }
                var res = string.Format("Please Upload a image.");
                dict.Add("error", res);
                return Request.CreateResponse(HttpStatusCode.NotFound, dict);
            }
            catch (Exception ex)
            {
                var res = string.Format("some Message");
                dict.Add("error", res);
                return Request.CreateResponse(HttpStatusCode.NotFound, dict);
            }//
        }
        [HttpPost]
        [Route("api/Productorder")]
        [AllowAnonymous]
        public IHttpActionResult ProductOrder(tblProductOrder productOrder)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new ApplicationDbContext())
            {
                ctx.ProductOrder.Add(new tblProductOrder
                {
                    ProductOrderId = productOrder.ProductOrderId,
                    ProductId = productOrder.ProductId,
                    OrderId = productOrder.OrderId,
                   // ProductOrderPayments = productOrder.ProductOrderPayments
                });

                ctx.SaveChanges();
            }

            return Ok();
        }

        [HttpPut]
        [Route("api/UpdateProductOrder")]
        [AllowAnonymous]
        public IHttpActionResult UpdateProductorder(tblProductOrderPayment productOrder)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var ctx = new ApplicationDbContext())
            {
                var productorder = ctx.ProductOrder.Where(s => s.ProductOrderId == productOrder.ProductOrderId)
                                                        .FirstOrDefault<tblProductOrder>();

                if (productorder != null)
                {

                    productorder.ProductOrderId = productOrder.ProductOrderId;
                   // productorder.ProductId = productOrder.ProductId;
        
                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
        }



        [HttpPost]
        [Route("api/ProductPayment")]
        [AllowAnonymous]
        public IHttpActionResult Productpayment(tblProductOrderPayment productPayment)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new ApplicationDbContext())
            {
                ctx.ProductOrderPayment.Add(new tblProductOrderPayment
                {
                    ProductOrderPaymentId = productPayment.ProductOrderPaymentId,
                    ProductOrderId = productPayment.ProductOrderId,
                    PaymentId = productPayment.PaymentId,
                    CardNumber = productPayment.CardNumber,
                    BankName = productPayment.BankName,
                    NameOnCard = productPayment.NameOnCard,
                    ExpiryDate = productPayment.ExpiryDate,
                    UserId = productPayment.UserId,

                });

                ctx.SaveChanges();
            }

            return Ok();
        }

        [HttpPut]
        [Route("api/UpdateProductPayment")]
        [AllowAnonymous]
        public IHttpActionResult UpdateProductPayment(tblProductOrderPayment productPayment)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var ctx = new ApplicationDbContext())
            {
                var productPayments = ctx.ProductOrderPayment.Where(s => s.ProductOrderPaymentId == productPayment.ProductOrderPaymentId)
                                                        .FirstOrDefault<tblProductOrderPayment>();

                if (productPayments != null)
                {
                    productPayments.ProductOrderId = productPayment.ProductOrderId;
                    productPayments.ProductOrderPaymentId = productPayment.ProductOrderPaymentId;
                    productPayments.ProductOrderId = productPayment.ProductOrderId;
                    productPayments.PaymentId = productPayment.PaymentId;
                    productPayments.CardNumber = productPayment.CardNumber;
                    productPayments.BankName = productPayment.BankName;
                    productPayments.NameOnCard = productPayment.NameOnCard;
                    productPayments.ExpiryDate = productPayment.ExpiryDate;
                    productPayments.UserId = productPayment.UserId;

                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
        }

    }
}