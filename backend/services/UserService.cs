using backend.Models;
using backend.Repository;

namespace backend.Services;

public class UserService
{
    private readonly ILogger<UserService> _logger;
    private readonly UserRepository _userRepository;
    private readonly EncryptionService _encryptionService;

    public UserService(ILogger<UserService> logger, UserRepository userRepository, EncryptionService encryptionService)
    {
        _logger = logger;
        _userRepository = userRepository;
        _encryptionService = encryptionService;
    }

    public async Task<List<User>> GetAllUsers()
    {
        var users = await _userRepository.GetAsync();
        foreach(User user in users)
        {
            user.email = await _encryptionService.DecryptString(user.email);
        }
        _logger.LogInformation("Fetched all users");

        return users;
    }

    public async Task CreateNewUser(User newUser)
    {
        var encryptedEmail = await _encryptionService.EncryptString(newUser.email);
        newUser.email = encryptedEmail;

        await _userRepository.CreateAsync(newUser);
        _logger.LogInformation($"Created new user with name {newUser.name}");
    }
}

