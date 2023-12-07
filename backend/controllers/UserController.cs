[ApiController]
[Route("/api/users")]
public class UserController : ControllerBase {

  private IUserService _userService;

  public UserController(IUserService userService){
    _userService = userService;
  }

  [HttpGet]
  [ProducesResponseType(StatusCodes.Status200Ok)]
  public ActionResult<User[]> Get() {
    this
  }


  [HttpPost]
  [ProducesResponseType(StatusCodes.Status201Created)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  public ActionResult<User> Create(User user)
  {
      pet.Id = _petsInMemoryStore.Any() ? 
              _petsInMemoryStore.Max(p => p.Id) + 1 : 1;
      _petsInMemoryStore.Add(pet);

      return CreatedAtAction(nameof(GetById), new { id = pet.Id }, pet);
  }
}