using System;
using System.Collections.Generic;

namespace PowerBsRise
{
    public class Constants
    {
        public const string PATH_TO_RESOURCES = "D:\\Programming\\C#\\Rakete_Mentoring\\PowerBsRise\\PowerBsRise\\Resources\\";
        public const string USERS_ACCOUNT_FILE = "UserAccounts.json";
        public const string HOSTS_DATA_FILE = "hosts.json";
        public const string DISPLAY_UNITS_DATA_FILE = "display_units.json";
        public const string SKINS_DATA_FILE = "skins.json";
        public const string DAY_PARTS_DATA_FILE = "day_parts.json";
        public const string BS_PRD_API_ENDPOINT = @"https://api.broadsign.com:10889";
        readonly public static List<string> MAIN_MENU_OPTIONS = new List<string> { "Opening hours", "My profile", "Logout" };
        readonly public static List<string> OPENING_HOURS_MENU_OPTIONS = new List<string> { "Get Opening Hours","Update Opening Hours", "Convert Opening Hours"};
        readonly public static List<string> PROFILE_MENU_OPTIONS = new List<string> { "Change Password", "My Permissions"};
        public const int MENU_OPENING_HOURS = 0;
        public const int MENU_PROFILE = 1;
        public const int MENU_LOGOUT = 2;
        public const int OPERATING_HOUR_FETCH_OPTION = 0;
        public const int OPERATING_HOUR_UPDATE_OPTION = 1;        
        public const int OPERATING_HOUR_CONVERT_OPTION = 2;

        public const string DSIPLAY_UNITS = "/rest/display_unit/v12";
    }
}
