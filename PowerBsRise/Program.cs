using PowerBsRise.Models;
using System;
using System.IO;
using System.Security.Authentication;

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
                try
                {
                    User.Authenticate(userName, password);
                }
                catch (FileNotFoundException)
                {
                    UserInterface.DisplayUserNotFoundMessage(Constant.PATH_TO_JSON_DATABASE);
                }
                catch (UserNotFoundException)
                {
                    UserInterface.DisplayUserNotFoundMessage(userName);
                }
                catch(AuthenticationException)
                {
                    UserInterface.DisplayUserPasswordCombinationIncorrectMessage(userName);
                }
                catch(Exception ex)
                {
                    UserInterface.DisplayUnexpectedException(ex.Message);
                }
                if (User.GetUserAuthenticationStatus() == Authorization.Unauthorized) UserInterface.DisplayUserAuthenticationFailed();
            }
            UserInterface.DisplayUserAuthenticationSucceded(User.Name);
        }
    }
}