using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebshopProject.Models;

namespace ShopAPI.Controllers
{
    public class CartController : ApiController
    {
        //Webshop database model
      

        // GET api/Cart
        public IEnumerable<string> Get()
        {
            return new string[] { "movie1", "movie2" };
        }

        // GET api/Cart/5
        public string Get(int id)
        {
            return "movie";
        }

        // POST api/Cart
        public void Post([FromBody]string value)
        {
        }

        // PUT api/Cart/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/Cart/5
        public void Delete(int id)
        {
        }
    }
}