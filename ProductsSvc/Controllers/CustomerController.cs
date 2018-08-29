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
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        private readonly CustomerApplicationService _service;
        public CustomerController(CustomerApplicationService service)
        {
            _service = service;
        }

        [Route("getallcustomers")]
        [HttpGet]
        public IHttpActionResult GetAllCustomers()
        {
            return Ok(_service.GetAllCustomers());
        }
       
        [HttpGet]
        [Route("getcustomersbyid")]
        public IHttpActionResult GetCustomersById(int id)
        {
            return Ok(_service.GetCustomerById(id));
        }

        [Route("addcustomer")]
        [HttpPost]
        public IHttpActionResult AddCustomer(Customer customer)
        {
            _service.AddCustomer(customer);
            return Ok();
        }

        [Route("updatecustomer")]
        [HttpPost]
        public IHttpActionResult UpdateCustomer(Customer customer)
        {
            _service.UpdateCustomer(customer);
            return Ok();
        }
        [Route("deletecustomer")]
        [HttpPost]
        public IHttpActionResult DeleteCustomer(int id)
        {
            _service.DeleteCustomer(id);
            return Ok();
        }
    }
}
