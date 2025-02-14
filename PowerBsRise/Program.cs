using Microsoft.VisualBasic;
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
            while (true)
            {
                UserInterface.DisplayMenu(Constants.MAIN_MENU_OPTIONS);
                string choice = UserInterface.GetEndUserMenuOptionChoice();

                //TODO consider using a dedicated function to check the errors and return the exception.
                if (choice == null)
                {
                    throw new ArgumentNullException(nameof(choice));
                }
                if (!IsValidInteger(choice)) //checks if choice is a valid int
                {
                    throw new InvalidCastException();
                }
                int parsedChoice = Convert.ToInt32(choice); //convert text base integer into an actual integer
                NavigateToSubMenu(parsedChoice); //only for test 
            }                  
        }
        static void NavigateToSubMenu(int menuOptionIndex)
        {
            string choice = "";
            try
            {             
                switch (menuOptionIndex)
                {
                    case Constants.MENU_OPENING_HOURS:
                        //display opening hours menu options
                        UserInterface.DisplayMenu(Constants.OPENING_HOURS_MENU_OPTIONS);
                        //Ask the end user to enter an menu option index
                        choice = UserInterface.GetEndUserMenuOptionChoice();
                        //Making sure the given menu index is a valid digit
                        if (!IsValidInteger(choice)) { throw new InvalidCastException(); }
                        //Converting the text based digit into an actual integer
                        int parsedChoice = Convert.ToInt32(choice);
                        //invoking function for working into menu option Opening Hours
                        NavigateInOperatingHours(parsedChoice);
                        break;
                    case Constants.MENU_PROFILE:
                        //Display profile menu options
                        UserInterface.DisplayMenu(Constants.PROFILE_MENU_OPTIONS);
                        //MORE LATER
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
                //is raised when choice is invalid
                UserInterface.DisplayInvalidCastErrorExceptionMessage(e.Message);
            }
     
        }
        //TODO consider putting this in logic
        static bool IsValidInteger(string textValue)
        {
            return int.TryParse(textValue, out int parsedChoice);
        }
        static void NavigateInOperatingHours(int menuOptionIndex)
        {
            string choice = "";
            try
            {
                switch (menuOptionIndex)
                {
                    case Constants.OPERATING_HOUR_FETCH_OPTION:
                        break;
                    case Constants.OPERATING_HOUR_UPDATE_OPTION:
                        break;
                    case Constants.OPERATING_HOUR_CONVERT_OPTION:
                        break;
                    default:
                        break;
                }
            }
        }
    }
}