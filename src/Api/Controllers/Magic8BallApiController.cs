using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("[controller]")]
    public class Magic8BallApiController : Controller
    {
        static Random _r = new Random();
        private Models.EightBallAnswers answers = new Models.EightBallAnswers();
        // GET: api/values
        [HttpGet]
        public string Get()
        {
            int rInt = _r.Next(0, answers.Count() - 1);
            return answers[rInt];
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return answers[Math.Min(Math.Max(0, id), answers.Count() - 1)];
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            throw new NotImplementedException("The all Mighty Crazy 8 Ball already has all the answers.");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException("You think you're worthy of submitting answers to the all Mighty Crazy 8 Ball.");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException("No one may delete answers from the all Mighty Crazy 8 Ball.");
        }
    }
}
