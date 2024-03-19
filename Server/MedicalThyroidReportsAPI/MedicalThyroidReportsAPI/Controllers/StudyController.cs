using Microsoft.AspNetCore.Mvc;
using MedicalThyroidReportsAPI.Modals;
using MedicalThyroidReportsAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalThyroidReportsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudyController : ControllerBase
    {
        private readonly StudyRepository _studyRepository;

        public StudyController(StudyRepository studyRepository)
        {
            _studyRepository = studyRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Study>>> GetAllStudies()
        {
            try
            {
                var studies = await _studyRepository.GetAllStudiesAsync();
                return Ok(studies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Study>> GetStudyById(int id)
        {
            try
            {
                var study = await _studyRepository.GetStudyByIdAsync(id);
                if (study == null)
                {
                    return NotFound($"Study with ID {id} not found");
                }
                return Ok(study);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Study>> AddStudy(Study study)
        {
            try
            {
                await _studyRepository.AddStudyAsync(study);
                return CreatedAtAction(nameof(GetStudyById), new { id = study.Id }, study);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ModifyStudy(int id, Study study)
        {
            try
            {
                var existingStudy = await _studyRepository.GetStudyByIdAsync(id);
                if (existingStudy == null)
                {
                    return NotFound($"Study with ID {id} not found");
                }
                study.Id = id; // Ensure the ID remains unchanged
                await _studyRepository.UpdateStudyAsync(study);
                return Ok("Study created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudy(int id)
        {
            try
            {
                var existingStudy = await _studyRepository.GetStudyByIdAsync(id);
                if (existingStudy == null)
                {
                    return NotFound($"Study with ID {id} not found");
                }
                await _studyRepository.DeleteStudyAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
