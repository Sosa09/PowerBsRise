﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerBsRise.Models
{
    public class Group
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
        private List<Permission> _permissions;
        public List<Permission> Permissions
        {
            get { return _permissions; }
            set { _permissions = value; }
        }
    }
}
