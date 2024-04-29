using MedicalThyroidReports.Modals;
using MedicalThyroidReports.Repostories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalThyroidReports.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly AboutRepository _aboutRepository;
       public AboutController(AboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }
        // GET: api/<AboutController>
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetAbouts()
        {
            var Abouts = _aboutRepository.GetAllAbouts();
            return Ok(Abouts);
        }

        // GET api/<AboutController>/5
        [HttpGet("{id}")]
        public ActionResult<About> GetAboutById(int id)
        {
          var About=_aboutRepository.GetAboutById(id);
            if(About == null)
            {
                return NotFound();
            }
            else { return Ok(About); }
        }

        // POST api/<AboutController>
        [HttpPost]
        public IActionResult PostAbout([FromBody] About about)
        {
            _aboutRepository.CreateAbout(about);
            return CreatedAtAction(nameof(GetAboutById), new { id = about.Id });
        }

        // PUT api/<AboutController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] About about)
        {
            if(id != about.Id)
            {
                return BadRequest();    
            }
            else
            {
                _aboutRepository.UpdateAbout(about);
                return Ok("Updated successfully");
            }
        }

        // DELETE api/<AboutController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var about=_aboutRepository.GetAboutById(id);
            if(about != null)
            {
                return NotFound();
            }
            else
            {
                _aboutRepository.DeleteAbout(id);
                return NoContent();
                    
            }
        }
    }
}
