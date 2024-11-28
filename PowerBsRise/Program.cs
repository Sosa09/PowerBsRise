using PowerBsRise.Models;

namespace PowerBsRise
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (User.GetUserAuthenticationStatus() == Authorization.Unauthorized)
            {
                string userName = UserInterface.GetUserName();
                string password = UserInterface.GetPassword();
                User.Authenticate(userName, password);
                if (User.GetUserAuthenticationStatus() == Authorization.Unauthorized) UserInterface.DisplayUserAuthenticationFailed();
            }
            UserInterface.DisplayUserAuthenticationSucceded(User.Name);
        }
    }
}