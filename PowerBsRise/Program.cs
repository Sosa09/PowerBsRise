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
                UserInterface.DisplayMenu(Constant.MAIN_MENU_OPTIONS);
                string choice = UserInterface.GetEndUserMenuOptionChoice();
                maxOptionCount = Constant.MAIN_MENU_OPTIONS.Count;
                GoToMenu(maxOptionCount, choice); //only for test 
            }                  
        }
        /// <summary>
        /// function will handle the navigation in the different menus it takes 2 params one that will count the total elements present in the displayed menu 
        /// and other one is used to navigate to the correct menu
        /// </summary>
        /// <param name="maxOptionCount"></param>
        /// <param name="choice"></param>
        static void GoToMenu(int maxOptionCount, string choice)
        {
            try
            {
                //todo: consider using a dedicated function to check the errors and return the exception.
                if (choice == null)
                {
                    throw new ArgumentNullException(nameof(choice));    
                }
                if (!int.TryParse(choice, out int parsedChoice))
                {
                    throw new InvalidCastException();
                }
                if (parsedChoice > maxOptionCount)
                {
                    throw new IndexOutOfRangeException();
                }
            }
            catch (ArgumentNullException e)
            {
                //todo
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