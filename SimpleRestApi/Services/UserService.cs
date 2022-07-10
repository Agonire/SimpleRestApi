using SimpleRestApi.Models;

namespace SimpleRestApi.Services
{
    public class UserService : IUserService
    {
        List<User> UserPersistanceMock = new List<User>()
        {
            new User("Super", "Hero"),
        };
        public User? Authenticate(string? username, string? password)
        {
            return UserPersistanceMock.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
