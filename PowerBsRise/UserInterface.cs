using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("The usernaem and/or password you've entered is incorrect, please try again");
        }
        internal static void DisplayUserAuthenticationSucceded(string name)
        {
            Console.WriteLine($"Welcome, {name}");
        }
    }
}