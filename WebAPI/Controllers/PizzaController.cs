using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Data;
using Model;

namespace WebAPI.Controllers
{
    public class PizzaController : ApiController
    {
        // GET: 
        public IEnumerable<Pizza> Get()
        {
            return new PizzaDB().Select();
        }

        // POST 
        public bool Post([FromBody] Pizza pizza)
        {
            return new PizzaDB().Insert(pizza);
        }

        public bool Delete([FromBody] Pizza pizza)
        {
            return new PizzaDB().Delete(pizza);
        }


    }
}