using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalThyroidReportsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaitentController : ControllerBase
    {
        // GET: api/<PaitentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PaitentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PaitentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PaitentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PaitentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
