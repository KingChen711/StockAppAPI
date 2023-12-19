
using Microsoft.AspNetCore.Mvc;
using StockAPI.BusinessLogic.Interfaces;
using StockAPI.DTO.User;

namespace StockAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userRepository)
    {
        _userService = userRepository;
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterDto body)
    {
        try
        {
            return Ok(body);
        }
        catch (ArgumentException e)
        {
            return BadRequest(new { Message = e.Message });
        }
    }
}
