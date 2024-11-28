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
    }
}
