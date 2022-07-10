using SimpleRestApi.Models;

namespace SimpleRestApi.Services
{
    public interface IUserService
    {
        User? Authenticate(string? username, string? password);
    }
}