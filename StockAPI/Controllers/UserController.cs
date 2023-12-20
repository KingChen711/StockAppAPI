
using Microsoft.AspNetCore.Mvc;
using StockAPI.BusinessLogic.Interfaces;
using StockAPI.DTO.User;

namespace StockAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterDto body)
    {
        try
        {
            return Ok(_userService.Register(body.Username, body.Email, body.Password));
        }
        catch (ArgumentException e)
        {
            return BadRequest(new { e.Message });
        }
    }
}
