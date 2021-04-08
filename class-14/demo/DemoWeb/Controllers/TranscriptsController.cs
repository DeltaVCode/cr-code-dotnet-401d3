using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoWeb.Controllers
{
    [Route("api/Students/{studentId}/Transcript")]
    [ApiController]
    public class TranscriptsController : ControllerBase
    {
        // GET: api/<TranscriptsController>
        [HttpGet]
        public IEnumerable<string> Get(int studentId)
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TranscriptsController>/5
        [HttpGet("{id}")]
        public string Get(int studentId, int id)
        {
            return "value";
        }

        // POST api/<TranscriptsController>
        [HttpPost]
        public void Post(int studentId, [FromBody] string value)
        {
        }

        // PUT api/<TranscriptsController>/5
        [HttpPut("{id}")]
        public void Put(int studentId, int id, [FromBody] string value)
        {
        }

        // DELETE api/<TranscriptsController>/5
        [HttpDelete("{id}")]
        public void Delete(int studentId, int id)
        {
        }
    }
}
