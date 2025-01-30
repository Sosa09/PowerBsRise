using PowerBsRise.Models;
using PowerBsRise.Services;
using PowerBsRise.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Authentication;
using System.Xml.Serialization;

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
                GenerateMainMenu();
                ChooseMenuOption(Constant.MAX_MAIN_MENU_VALUE); //only for test 
            }                  
        }
        /// <summary>
        /// Used to generate the different menus accross the tool.
        /// by passing some arguments the tool will redirect the end user to the main menu or sub menus depending on the end user's choice
        ///
        /// </summary>
        static void GenerateMainMenu()
        {            
            UserInterface.DisplayMenu(Constant.MAIN_MENU_OPTIONS);
        }
        /// <summary>
        /// function that will handle the end users menu option choice
        /// </summary>
        static int ChooseMenuOption(int maxOptionCount)
        {
            //consider adding a max position that way if the end user enter a position that does not exists throw indexoutofrangeexcep.
            int position = 0;
            try
            {
                string choice = UserInterface.GetEndUserMenuOptionChoice();
                if (choice == null)
                {
                    throw new ArgumentNullException(nameof(choice));    
                }
                if (!int.TryParse(choice, out position))
                {
                    throw new InvalidCastException();
                }
                if (position > maxOptionCount)
                {
                    throw new IndexOutOfRangeException();
                }
                return position;
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
            return position;
        }
    }
}