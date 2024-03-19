using Microsoft.AspNetCore.Mvc;
using MedicalThyroidReportsAPI.Modals;
using MedicalThyroidReportsAPI.Repositories;

namespace MedicalThyroidReportsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudyThyroidController:ControllerBase
    {
        private readonly StudyThyroidRepository _studyThyroidRepository;

        public StudyThyroidController(StudyThyroidRepository studyThyroidRepository)
        {
            _studyThyroidRepository = studyThyroidRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudyThyroid>>> GetAllStudyThyroids()
        {
            var studyThyroids = await _studyThyroidRepository.GetAllStudyThyroidsAsync();
            return Ok(studyThyroids);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudyThyroid>> GetStudyThyroidById(int id)
        {
            var studyThyroid = await _studyThyroidRepository.GetStudyThyroidByIdAsync(id);
            if (studyThyroid == null)
            {
                return NotFound();
            }
            return Ok(studyThyroid);
        }

        [HttpPost]
        public async Task<ActionResult<StudyThyroid>> AddStudyThyroid(StudyThyroid studyThyroid)
        {
            await _studyThyroidRepository.AddStudyThyroidAsync(studyThyroid);
            return CreatedAtAction(nameof(GetStudyThyroidById), new { id = studyThyroid.Id }, studyThyroid);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ModifyStudyThyroid(int id, StudyThyroid studyThyroid)
        {
            if (id != studyThyroid.Id)
            {
                return BadRequest();
            }

            try
            {
                await _studyThyroidRepository.UpdateStudyThyroidAsync(studyThyroid);
            }
            catch (Exception)
            {
                if (await _studyThyroidRepository.GetStudyThyroidByIdAsync(id) == null)
                {
                    return NotFound();
                }
                throw;
            }

            return Ok("Created successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudyThyroid(int id)
        {
            var studyThyroid = await _studyThyroidRepository.GetStudyThyroidByIdAsync(id);
            if (studyThyroid == null)
            {
                return NotFound();
            }

            await _studyThyroidRepository.DeleteStudyThyroidAsync(id);
            return Ok("Deleted successfully");
        }
    }
}
