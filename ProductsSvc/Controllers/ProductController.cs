using ApplicationLayer;
using DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductsSvc.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        private readonly ProductApplicationService _service;
        public ProductController(ProductApplicationService service)
        {
            _service = service;
        }

        //[HttpGet]
        //public IHttpActionResult Get()
        //{
        //    return Ok(_service.Hello());
        //}
        [Route("getallproducts")]
        [HttpGet]
        public IHttpActionResult GetAllProducts()
        {

            return Ok(_service.GetAllProducts());
        }
        [HttpGet]
        [Route("getavilableproducts")]
        public IHttpActionResult GetAvilableProducts()
        {
            return Ok(_service.GetAvilableProducts());
        }
        [HttpGet]
        [Route("getcompletedproducts")]
        public IHttpActionResult GetCompletedProducts()
        {
            return Ok(_service.GetCompletedProducts());
        }

        [Route("addproduct")]
        [HttpPost]
        public IHttpActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, "Product object is empty or null");
            }

            _service.AddProduct(product);
            return Ok();
        }

        [Route("updateproduct")]
        [HttpPost]
        public IHttpActionResult UpdateProduct(Product product)
        {
            _service.UpdateProduct(product);
            return Ok();
        }
        [Route("deleteproduct")]
        [HttpPost]
        public IHttpActionResult DeleteProduct(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}
