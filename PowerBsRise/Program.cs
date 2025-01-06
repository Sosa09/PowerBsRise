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
                try
                {
                    string userName = UserInterface.GetUserName();
                    string password = UserInterface.GetPassword();
                    User.Authenticate(userName, password);
                }
                catch (FileNotFoundException)
                {

                }
                catch (UserNotFoundException)
                {

                }
                catch(AuthenticationException)
                {

                }
                catch(Exception ex)
                {

                }

                if (User.GetUserAuthenticationStatus() == Authorization.Unauthorized) UserInterface.DisplayUserAuthenticationFailed();
            }

            UserInterface.DisplayUserAuthenticationSucceded(User.Name);
        }


    }
}