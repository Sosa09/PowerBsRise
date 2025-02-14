using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace PowerBsRise.Views
{
    public static class UserInterface
    {
        public static string GetUserName()
        {
            Console.WriteLine("Please enter your username");
            return Console.ReadLine();
        }
        public static string GetPassword()
        {
            Console.WriteLine("Please enter your password");
            return Console.ReadLine();
        }
        public static void DisplayUserAuthenticationFailed()
        {
            Console.WriteLine("The username and/or password you've entered is incorrect, please try again");
        }
        public static void DisplayUserAuthenticationSucceded(string name)
        {
            Console.WriteLine($"Welcome, {name}");
        }
        public static void DisplayUserNotFoundMessage(string username)
        {
            Console.WriteLine($"username: {username} could not be found in the database, check your username and try again !");
        }
        public static void DisplayUserPasswordCombinationIncorrectMessage(string username)
        {
            Console.WriteLine($"The comination of the username {username} and password does not match !");
        }
        public static void DisplayMenu(List<string> mainMenu)
        {
            int position = 0;
            mainMenu.ForEach(x => Console.WriteLine($"{position++}: {x}"));
        }
        public static string GetEndUserMenuOptionChoice()
        {
            Console.WriteLine("Enter your choice: ");
            return Console.ReadLine();
        }

        public static void DisplayInvalidMenuOptionMessage(string errorMessage)
        {
            Debug.WriteLine(errorMessage);
            Console.WriteLine($"{errorMessage}\nThe menu option you try to access is not a valid option, please try again.");
        }

        public static void DisplayInvalidCastErrorExceptionMessage(string errorMessage)
        {
            Debug.WriteLine(errorMessage);
            Console.WriteLine($"The value you've entered is not valid, please try again");
        }
        public static void DisplayUnexpectedExceptionMessage(string errorMessage)
        {
            Debug.WriteLine(errorMessage);
            Console.WriteLine(errorMessage);
        }
        public static void DisplayFileNotFoundExceptionMessage(string errorMessage)
        {
            Debug.WriteLine($"{errorMessage}");
            Console.WriteLine("The file you try to access doesn't exists, please try again.");
        }

        internal static void DisplayMenu(object oPENING_HOURS_MENU_OPTIONS)
        {
            throw new NotImplementedException();
        }

        internal static void DisplayTestDataMessage()
        {
            Console.WriteLine("The system is running in test mode you ll see information that is not relevant or unnecessary");
        }

    }
}