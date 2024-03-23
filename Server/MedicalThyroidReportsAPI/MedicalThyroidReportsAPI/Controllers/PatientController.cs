using MedicalThyroidReportsAPI.Modals;
using MedicalThyroidReportsAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalThyroidReportsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly PatientRepository _patientRepository;
        public PatientController(PatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            try
            {
                var patients = await _patientRepository.GetAllPatientsAsync();
                return Ok(patients);
            }
            catch (Exception ex) {
                return StatusCode(500, $"Error: {ex.Message} Connection string");
            }
        }
        [HttpGet ("{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            try
            {
                var patient = await _patientRepository.GetPatientByIdAsync(id);
                if(patient == null)
                {
                    return NotFound("Patient Not found");
                }
                return Ok(patient);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddPatient([FromBody] Patient patient)
        {
            try
            {
                await _patientRepository.AddPatientAsync(patient);
                return Ok("Patient created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");

            }

            
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> ModifyPatient(int id, [FromBody] Patient patient)
        {
            try
            {
                var existingPatient = await _patientRepository.GetPatientByIdAsync(id);
            if (existingPatient == null)
                {
                    return NotFound("Patient Not found");
                }
                patient.IdPatient = id;
                await _patientRepository.UpdatePatientAsync(patient);
                return Ok("Patient updated successfully");
            }
            catch(Exception ex) 
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            try
            {
                var existingPatient = await _patientRepository.GetPatientByIdAsync(id);
                if (existingPatient == null)
                {
                    return NotFound("Patient Not found.");
                }
                await _patientRepository.DeletePatientAsync(id);
                return Ok("Patient deleted successfully");
            }
            catch(Exception ex)
            {
                return StatusCode(500,$"Error: {ex.Message}");
            }
        }

        [HttpGet("patientswithstudies")]
        public IActionResult GetPatientsWithStudies()
        {
            try
            {
                var patientsWithStudies = _patientRepository.GetAllPatientsWithStudies();
                return Ok(patientsWithStudies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


    }
}
