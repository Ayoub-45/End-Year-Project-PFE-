using MedicalThyroidReports.Modals;
using MedicalThyroidReports.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class UserAuthController : ControllerBase
{
    private readonly IUserService _userService;

    public UserAuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest model)
    {
        // Validate input
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Attempt to register the user
        var result = await _userService.RegisterAsync(model);

        if (result.Success)
        {
            return Ok(new { message = "Registration successful" });
        }
        else
        {
            return BadRequest(new { message = result.ErrorMessage });
        }
    }
}
