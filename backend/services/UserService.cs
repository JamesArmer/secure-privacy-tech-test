using backend.Models;
using backend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services;

public class UserService
{
    private readonly UserRepository _userRepository;

    public UserService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<User>> GetAllUsers()
    {
        var users = await _userRepository.GetAsync();
        return users;
    }

    public async Task CreateNewUser(User newUser)
    {
        await _userRepository.CreateAsync(newUser);
    }
}

