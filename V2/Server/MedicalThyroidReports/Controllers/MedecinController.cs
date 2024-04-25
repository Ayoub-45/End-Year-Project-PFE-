using MedicalThyroidReports.Modals;
using MedicalThyroidReports.Repostories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace MedicalThyroidReports.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedecinController : ControllerBase
    {
       
  private readonly MedecinRepository _medecinRepository; // Assuming you have an interface IMedecinRepository

        public MedecinController(MedecinRepository medecinRepository)
        {
            _medecinRepository = medecinRepository;
        }

        // GET: api/Medecin
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var medecins = await _medecinRepository.GetAllAsync();
            return Ok(medecins);
        }

        // GET: api/Medecin/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var medecin = await _medecinRepository.GetByIdAsync(id);
            if (medecin == null)
            {
                return NotFound();
            }
            return Ok(medecin);
        }

        // POST: api/Medecin
        // POST: api/Medecin
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Medecin medecin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _medecinRepository.CreateAsync(medecin);
            return CreatedAtAction(nameof(GetById), new { id = medecin.Id }, medecin);
        }


        // PAtch: api/Medecin/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Medecin medecin)
        {
            if (id != medecin.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _medecinRepository.UpdateAsync(medecin);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return NoContent();
        }

        // DELETE: api/Medecin/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _medecinRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
