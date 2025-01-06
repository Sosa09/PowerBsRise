using System;

namespace PowerBsRise
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
        internal static void DisplayUserAuthenticationSucceded(string name)
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
        public static void DisplayUnexpectedException(string message)
        {
            Console.WriteLine(message);
        }
    }
}