using MedicalThyroidReports.Modals;
using MedicalThyroidReports.Repostories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalThyroidReports.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
        public class SpecialiteController : ControllerBase
        {
            private readonly SpecialiteRepository _specialiteRepository;

            public SpecialiteController(SpecialiteRepository specialiteRepository)
            {
                _specialiteRepository = specialiteRepository;
            }

            [HttpGet]
            public ActionResult<IEnumerable<Specialite>> Get()
            {
                var specialites = _specialiteRepository.GetAllSpecialtes();
                return Ok(specialites);
            }

            [HttpGet("{id}")]
            public ActionResult<Specialite> Get(int id)
            {
                var specialite = _specialiteRepository.GetSpecialteById(id);
                if (specialite == null)
                {
                    return NotFound();
                }
                return Ok(specialite);
            }

            [HttpPost]
            public IActionResult Post([FromBody] Specialite specialite)
            {
            _specialiteRepository.CreateSpecialite(specialite);
                return CreatedAtAction(nameof(Get), new { id = specialite.Id }, specialite);
            }

            [HttpPatch("{id}")]
            public IActionResult Put(int id, [FromBody] Specialite specialite)
            {
                if (id != specialite.Id)
                {
                    return BadRequest();
                }

                _specialiteRepository.UpdateSpecialte(specialite);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                var specialite = _specialiteRepository.GetSpecialteById(id);
                if (specialite == null)
                {
                    return NotFound();
                }

                _specialiteRepository.DeleteSpecialte(id);
                return NoContent();
            }
        }
    }
