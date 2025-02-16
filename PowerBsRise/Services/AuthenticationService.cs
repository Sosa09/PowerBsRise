using PowerBsRise.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace PowerBsRise.Services
{
    public static class AuthenticationService
    {
        public static User AuthenticateUser(string username, string password)
        {
            //instruction to authenticate
            string db_Path = Constants.PATH_TO_RESOURCES + Constants.USERS_ACCOUNT_FILE;
            string rawContent = File.ReadAllText(db_Path);
            List<User> users = JsonConvert.DeserializeObject<List<User>>(rawContent);
            User user = users.Where(x => x.Name == username).First();
            if (user == null){
                throw new UserNotFoundException();
            }
            user.SetUserAuhtenticationStatus(Authorization.Authorized);
            return user;
        }        
    }
}