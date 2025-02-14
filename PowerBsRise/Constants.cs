using System.Collections.Generic;

namespace PowerBsRise
{
    public class Constants
    {
        public const string PATH_TO_RESOURCES = "D:\\Programming\\C#\\Rakete_Mentoring\\PowerBsRise\\PowerBsRise\\Resources\\";
        public const string FILE_NAME_JSON_DATABASE = "UserAccounts.json";
        readonly public static List<string> MAIN_MENU_OPTIONS = new List<string> { "Opening hours", "My profile", "Logout" };
        readonly public static List<string> OPENING_HOURS_MENU_OPTIONS = new List<string> { "Update Opening Hours", "Get Opening Hours", "Convert Opening Hours"};
        readonly public static List<string> PROFILE_MENU_OPTIONS = new List<string> { "Change Password", "My Permissions"};
        public const int MENU_OPENING_HOURS = 0;
        public const int MENU_PROFILE = 1;
        public const int MENU_LOGOUT = 2;
    }
}
