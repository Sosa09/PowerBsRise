using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerBsRise.Models
{
    public static class User
    {
        private static int _id;
        public static int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        private static string _name;
        public static string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private static Role _role;
        public static Role Role
        {
            get { return _role; }
            set { _role = value; }
        }
        private static List<Group> _groups;
        public static List<Group> Groups
        {
            get { return _groups; }
            set { _groups = value; }
        }
        private static List<Permission> _permissions;
        public static List<Permission> Permissions
        {
            get { return _permissions; }
            set { _permissions = value; }
        }
        private static Authorization _userAuthenticationStatus = Authorization.Unauthorized;
        public static void Authenticate(string username, string password)
        {
            //write instruction to check wether a user exists or not and return an exception if user not exists
        }
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
