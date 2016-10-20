using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiDemo.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values/{id}
        public string Get(string id)
        {
            return id;
        }

        // POST api/values
        public TestModel Post(TestModel model)
        {
            return model;
        }

        // POST api/values/{id}
        public TestModel Post(string id)
        {
            return new TestModel {Name = id};
        }
    }

    public class TestModel 
    {
        public string Name { get; set; }
    }
}
