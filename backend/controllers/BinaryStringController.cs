using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/binary")]
public class BinaryStringController : ControllerBase
{
    private readonly ILogger<BinaryStringController> _logger;
    private readonly BinaryStringService _BinaryStringService;

    public BinaryStringController(ILogger<BinaryStringController> logger, BinaryStringService binaryStringService)
    {
        _logger = logger;
        _BinaryStringService = binaryStringService;
    }

    [HttpGet("{binary}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult Get(string binary)
    {
        var result = _BinaryStringService.Evaluate(binary);
        return Ok($"{result}");
    }
}

