using Microsoft.AspNetCore.Mvc;
using MedicalThyroidReports.Modals;
using System.Threading.Tasks;
using MedicalThyroidReports.Repositories;

namespace MedicalThyroidReports.Controllers
{

[Route("api/[controller]")]
[ApiController]
public class ExamenController : ControllerBase
{
    private readonly ExamenRepository _examenRepository;
   
    public ExamenController(ExamenRepository examenRepository)
    {
        _examenRepository = examenRepository;
    }
    
    // GET: api/Examen
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var examens = await _examenRepository.GetAllAsync();
        return Ok(examens);
    }

    // GET: api/Examen/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var examen = await _examenRepository.GetByIdAsync(id);
        if (examen == null)
        {
            return NotFound();
        }
        return Ok(examen);
    }

    // POST: api/Examen
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Examen examen)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _examenRepository.CreateAsync(examen);
            return  CreatedAtAction(nameof(GetById), new { id = examen.Id }, examen);

        }

        // PUT: api/Examen/5
        [HttpPatch("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] Examen examen)
    {
        if (id != examen.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _examenRepository.UpdateAsync(examen);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }

        return NoContent();
    }

    // DELETE: api/Examen/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _examenRepository.DeleteAsync(id);
        return NoContent();
    }
}

}