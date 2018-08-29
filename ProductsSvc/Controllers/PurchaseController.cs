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
    [RoutePrefix("api/purchase")]
    public class PurchaseController : ApiController
    {
        private readonly PurchaseApplicationService _service;
        public PurchaseController(PurchaseApplicationService service)
        {
            _service = service;
        }

        [Route("getall")]
        [HttpGet]
        public IHttpActionResult GetAllPurchaseDetails()
        {
            return Ok(_service.GetAllPurchases());
        }

        [Route("buyproduct")]
        [HttpPost]
        public IHttpActionResult AddProduct(PurchaseDetails purchase)
        {
           bool blnretVal = _service.BuyProduct(purchase);
            if (!blnretVal)
            {
                return Content(HttpStatusCode.BadRequest, "Some of the data is not valid");
            }

            //_service.AddProduct(product);
            return Ok();
        }

    }
}
