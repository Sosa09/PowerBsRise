﻿using System.Collections.Generic;

namespace PowerBsRise
{
    public class Constants
    {
        public const string PATH_TO_RESOURCES = "D:\\Programming\\C#\\Rakete_Mentoring\\PowerBsRise\\PowerBsRise\\Resources\\";
        public const string FILE_NAME_JSON_DATABASE = "UserAccounts.json";
        readonly public static List<string> MAIN_MENU_OPTIONS = new List<string> { "Opening hours", "My profile", "Logout" };
        readonly public static List<string> OPENING_HOURS_MENU_OPTIONS = new List<string> { "Get Opening Hours","Update Opening Hours", "Convert Opening Hours"};
        readonly public static List<string> PROFILE_MENU_OPTIONS = new List<string> { "Change Password", "My Permissions"};
        public const int MENU_OPENING_HOURS = 0;
        public const int MENU_PROFILE = 1;
        public const int MENU_LOGOUT = 2;
        public const int OPERATING_HOUR_FETCH_OPTION = 0;
        public const int OPERATING_HOUR_UPDATE_OPTION = 1;        
        public const int OPERATING_HOUR_CONVERT_OPTION = 2;
    }
}
