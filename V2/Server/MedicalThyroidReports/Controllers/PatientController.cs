using MedicalThyroidReports.Modals;
using MedicalThyroidReports.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalThyroidReports.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        PatientRepository _patientRepository;
        // GET: api/<PatientController>
        public PatientController(PatientRepository patientRepository)
        {
            _patientRepository = patientRepository;

        }
        /// <summary>
        /// Adds a new patient.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> AddPatient([FromBody] Patient patient)
        {
            try
            {
                if (patient == null)
                {
                    return BadRequest("Patient object is null");
                }

                int newPatientId = await _patientRepository.AddPatientAsync(patient);
                return Ok("Patient created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        /// <summary>
        /// Gets all patients.
        /// </summary>

        [HttpGet]
        public ActionResult<IEnumerable<Patient>> GetPatients()
        {
            try
            {
                var patients = _patientRepository.GetAllPatients();
                return Ok(patients);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        /// <summary>
        /// Gets a patient by ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatientById(int id)
        {
            try
            {
                var patient = await _patientRepository.GetPatientByIdAsync(id);
                if (patient == null)
                {
                    return NotFound($"Patient with ID {id} not found");
                }
                return Ok(patient);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        /// <summary>
        /// Deletes a patient by ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePatient(int id)
        {
            try
            {
                var patientToDelete = await _patientRepository.GetPatientByIdAsync(id);
                if (patientToDelete == null)
                {
                    return NotFound($"Patient with ID {id} not found");
                }

                await _patientRepository.DeletePatientAsync(id);
                return Ok($"Patient {id} deleteted successfully."); // 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        /// <summary>
        /// Updates a patient by ID.
        /// </summary>

        [HttpPatch]
        public async Task<IActionResult> UpdatePatient(int id,[FromBody] Patient updatedPatient)
        {
            try
            {
                var existingPatient = await _patientRepository.GetPatientByIdAsync(id);
                if (existingPatient == null)
                {
                    return NotFound($"Patient with ID {id} not found");
                }

                updatedPatient.Id = id; // Ensure the ID in the request body matches the URL parameter

                await _patientRepository.UpdatePatientAsync(updatedPatient);
                return Ok($"Updated successufully patient {id}"); // 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        




    }
}
