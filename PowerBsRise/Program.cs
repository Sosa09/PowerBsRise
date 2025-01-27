using PowerBsRise.Models;
using PowerBsRise.Services;
using PowerBsRise.Views;
using System;
using System.IO;
using System.Security.Authentication;

namespace PowerBsRise
{
    public class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            //instruction to authenticate user
            while (user.GetUserAuthenticationStatus() == Authorization.Unauthorized)
            {
                //Ask username and password of the end user
                string userName = UserInterface.GetUserName();
                string password = UserInterface.GetPassword();
                try
                {
                    AuthenticationService.AuthenticateUser(userName, password);                    
                }
                catch (FileNotFoundException)
                {
                    UserInterface.DisplayUserNotFoundMessage(userName);
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
            }
            UserInterface.DisplayUserAuthenticationSucceded(user.Name);
        }
    }
}