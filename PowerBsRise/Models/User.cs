using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerBsRise.Models
{
    public static class User
    {
        public static int ID { get; set; }

        public static string Name { get; set; }

        public static Role Role { get; set; }

        public static List<Group> Groups { get; set; }

        public static List<Permission> Permissions { get; set; }
        private static Authorization _userAuthenticationStatus = Authorization.Unauthorized;

        public static void LoadProfile()
        {
            //can only be loaded if user has been authenticated properly
            //note! a new profile will be created if no profile was found !
            throw new NotImplementedException();
        }

        public static Authorization GetUserAuthenticationStatus()
        {
            return _userAuthenticationStatus;
        }
    }
}
