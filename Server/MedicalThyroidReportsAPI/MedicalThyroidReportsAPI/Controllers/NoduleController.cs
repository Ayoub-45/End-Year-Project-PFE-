using Microsoft.AspNetCore.Mvc;
using MedicalThyroidReportsAPI.Modals;
using MedicalThyroidReportsAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalThyroidReportsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoduleController : ControllerBase
    {
        private readonly NoduleRepository _noduleRepository;

        public NoduleController(NoduleRepository noduleRepository)
        {
            _noduleRepository = noduleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNodules()
        {
            try
            {
                var nodules = await _noduleRepository.GetAllNodulesAsync();
                return Ok(nodules);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNoduleById(int id)
        {
            try
            {
                var nodule = await _noduleRepository.GetNoduleByIdAsync(id);
                if (nodule == null)
                {
                    return NotFound("Nodule not found.");
                }
                return Ok(nodule);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateNodule([FromBody] Nodule nodule)
        {
            try
            {
                await _noduleRepository.AddNoduleAsync(nodule);
                return Ok("Nodule created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNodule(int id, [FromBody] Nodule nodule)
        {
            try
            {
                var existingNodule = await _noduleRepository.GetNoduleByIdAsync(id);
                if (existingNodule == null)
                {
                    return NotFound("Nodule not found.");
                }

                nodule.idNodule = id;
                await _noduleRepository.UpdateNoduleAsync(nodule);
                return Ok("Nodule updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNodule(int id)
        {
            try
            {
                var existingNodule = await _noduleRepository.GetNoduleByIdAsync(id);
                if (existingNodule == null)
                {
                    return NotFound("Nodule not found.");
                }

                await _noduleRepository.DeleteNoduleAsync(id);
                return Ok("Nodule deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
