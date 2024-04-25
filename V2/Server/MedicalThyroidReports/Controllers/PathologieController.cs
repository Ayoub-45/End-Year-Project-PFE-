using MedicalThyroidReports.Modals;
using MedicalThyroidReports.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
namespace MedicalThyroidReports.Controllers
{
[Route("api/[controller]")]
[ApiController]
public class PathologieController : ControllerBase
{
    private readonly PathologieRepository _pathologieRepository;

    public PathologieController(PathologieRepository pathologieRepository)
    {
        _pathologieRepository = pathologieRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Pathologie>> Get()
    {
        var pathologies = _pathologieRepository.GetAllPathologies();
        return Ok(pathologies);
    }

    [HttpGet("{id}")]
    public ActionResult<Pathologie> Get(int id)
    {
        var pathologie = _pathologieRepository.GetPathologieById(id);
        if (pathologie == null)
        {
            return NotFound();
        }
        return Ok(pathologie);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Pathologie pathologie)
    {
        _pathologieRepository.CreatePathologie(pathologie);
        return CreatedAtAction(nameof(Get), new { id = pathologie.Id }, pathologie);
    }

    [HttpPatch("{id}")]
    public IActionResult Put(int id, [FromBody] Pathologie pathologie)
    {
        var existingPathologie = _pathologieRepository.GetPathologieById(id);
        if (existingPathologie == null)
        {
            return NotFound();
        }
        pathologie.Id = id;
        _pathologieRepository.UpdatePathologie(pathologie);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var existingPathologie = _pathologieRepository.GetPathologieById(id);
        if (existingPathologie == null)
        {
            return NotFound();
        }
        _pathologieRepository.DeletePathologie(id);
        return NoContent();
    }
}
}

