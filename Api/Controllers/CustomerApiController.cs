using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    public class CustomerApiController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<global::Models.Customer> Get()
        {
            return new global::Models.Customer[] { new Data.Customer().GetByName("*") };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public global::Models.Customer Get(string name)
        {
            return new Data.Customer().GetByName(name);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
