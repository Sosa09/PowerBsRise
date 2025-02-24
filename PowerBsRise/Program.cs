using PowerBsRise.Models;
using PowerBsRise.Services;
using PowerBsRise.Views;
using System;
using System.IO;
using System.Net.Http;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace PowerBsRise
{
    public class Program
    {
        static void Main(string[] args)
        {

            //------------------------------------------------------------------------------------------------------------------
            //JUST SOME TEST BEFORE STARTING
            UserInterface.DisplayTestDataMessage();
            
            //------------------------------------------------------------------------------------------------------------------
            //TESTING API REQUEST
            //getting api token
            try
            {
                string token = UserInterface.GetApiToken();

                //IMPLEMETING QUICK TEST DATA TO DISPALY A DISPLAY UNIT CONFIRMING MY DATAHANDLER ISWORKING
                TestData td = new TestData(token); //will fetch display units when instance is created
                //USING HARDCODED TEXT JUST FOR THE TEST WILL BE DELETED!
                UserInterface.DisplayResourceContent(td.DisplayUnitObjects);
                UserInterface.DisplayResourceContent(td.HostObjects);
                UserInterface.DisplayResourceContent(td.DayPartObjects);
                UserInterface.DisplayResourceContent(td.SkinObjects);
            }
            catch (ArgumentException ex)
            {
                UserInterface.DisplayTestDataException(ex.Message);
            }
            catch (UriFormatException ex)
            {
                UserInterface.DisplayTestDataException(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                UserInterface.DisplayTestDataException(ex.Message);
            }
            catch (FormatException ex)
            {
                UserInterface.DisplayTestDataException(ex.Message); 
            }
            catch (HttpRequestException ex)
            {
                UserInterface.DisplayTestDataException(ex.Message); 
            }
            catch (TaskCanceledException ex)
            {
                UserInterface.DisplayTestDataException(ex.Message); 
            }
            catch (AggregateException ex)
            {
                UserInterface.DisplayTestDataException(ex.Message);
            }
            catch (Exception ex)
            {
                UserInterface.DisplayTestDataException(ex.Message);
            }
            //END TEST
            //------------------------------------------------------------------------------------------------------------------
            //------------------------------------------------------------------------------------------------------------------

            User user = new User();
            
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
                if (!ProgramLogic.IsValidInteger(choice)) //checks if choice is a valid int
                {
                    throw new InvalidCastException();
                }
                int parsedChoice = Convert.ToInt32(choice); //convert text base integer into an actual integer
                NavigateToSubMenu(parsedChoice); //only for test 
            }                  
        }
        static void NavigateToSubMenu(int menuOptionIndex)
        {
            string choice = string.Empty;
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
                        if (!ProgramLogic.IsValidInteger(choice)) { throw new InvalidCastException(); }
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
        static void NavigateInOperatingHours(int menuOptionIndex)
        {
            string choice = string.Empty;
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
            }catch (Exception e)
            {
                //more later
            }
        }
    }
}