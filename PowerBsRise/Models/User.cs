using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerBsRise.Models
{
    public class User
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private Role _pRole;
        public Role PRole
        {
            get { return _pRole; }
            set { _pRole = value; }
        }
        private List<Group> _groups;
        public List<Group> Groups
        {
            get { return _groups; }
            set { _groups = value; }
        }
        private List<Permission> _permissions;
        public List<Permission> Permissions
        {
            get { return _permissions; }
            set { _permissions = value; }
        }
    }
}
