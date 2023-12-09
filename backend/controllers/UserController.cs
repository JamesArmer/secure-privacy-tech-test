using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("/api/users")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly UserService _userService;

    public UserController(ILogger<UserController> logger, UserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpGet(Name = "GetAllUsers")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<List<User>> Get()
    {
        var result = await _userService.GetAllUsers();
        return result;
    }

    [HttpPost(Name = "CreateNewUser")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(User newUser)
    {
        await _userService.CreateNewUser(newUser);
        return CreatedAtAction(nameof(Get), new { id = newUser._id }, newUser);
    }
}

