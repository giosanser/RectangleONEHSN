using System.Security.Claims;
using System.Security.Principal;

namespace RectangleONEHSN.Authentication
{
    public interface IUserService
    {
        bool IsValidUser(string username, string password);
    }

    public class UserService : IUserService
    {
        public bool IsValidUser(string username, string password)
        {
            // Hardcoded credentials for testing purposes
            const string validUsername = "admin";
            const string validPassword = "password";

            // Compare the provided username and password with the valid credentials
            return username == validUsername && password == validPassword;
        }
    }
}
