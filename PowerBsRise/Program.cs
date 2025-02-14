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
            int maxOptionCount = new int();
            //instruction to authenticate user
            while (user.GetUserAuthenticationStatus() == Authorization.Unauthorized)
            {
                //Ask username and password of the end user
                string userName = UserInterface.GetUserName();
                string password = UserInterface.GetPassword();
                try
                {
                    user = AuthenticationService.AuthenticateUser(userName, password);                    
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
                    UserInterface.DisplayUnexpectedExceptionMessage(ex.Message);
                }
            }
            UserInterface.DisplayUserAuthenticationSucceded(user.Name);
            //use a while loop approach to enter to each sub menu or go back and while it s not log out keep looping
            while(true)
            {
                UserInterface.DisplayMenu(Constants.MAIN_MENU_OPTIONS);
                string choice = UserInterface.GetEndUserMenuOptionChoice();
                GoToMenu(choice); //only for test 
            }                  
        }
        static void GoToMenu(string choice)
        {
            try
            {
                //todo: consider using a dedicated function to check the errors and return the exception.
                if (choice == null)
                {
                    throw new ArgumentNullException(nameof(choice));
                }
                if (!int.TryParse(choice, out int parsedChoice)) //if parse succeeded parsedChoice will be used as the expression in the switch case to navigate
                {
                    throw new InvalidCastException();
                }
                switch (parsedChoice)
                {
                    case Constants.MENU_OPENING_HOURS:
                        //function to display sub menu
                        UserInterface.DisplayMenu(Constants.OPENING_HOURS_MENU_OPTIONS);
                        break;
                    case Constants.MENU_PROFILE:
                        //function to display sub menu
                        UserInterface.DisplayMenu(Constants.PROFILE_MENU_OPTIONS);
                        break;
                    case Constants.MENU_LOGOUT:
                        //logout return to login !
                        break;
                    default:
                        break;
                }
            }
            catch(InvalidCastException e)
            {
                UserInterface.DisplayInvalidCastErrorExceptionMessage(e.Message);
            }
            catch(IndexOutOfRangeException e)
            {
                UserInterface.DisplayInvalidMenuOptionMessage(e.Message);
            }         
        }
    }
}