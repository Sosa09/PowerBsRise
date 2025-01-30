using System.Collections.Generic;

namespace PowerBsRise.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
        public List<Group> Groups { get; set; }
        public List<Permission> Permissions { get; set; }
        private  Authorization _userAuthenticationStatus = Authorization.Unauthorized;
        public Authorization GetUserAuthenticationStatus()
        {
            return _userAuthenticationStatus;
        }
        public void SetUserAuhtenticationStatus(Authorization authorization)
        {
            _userAuthenticationStatus = authorization;
        }
    }
}
