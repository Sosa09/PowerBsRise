using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerBsRise.Models
{
    public class Host
    {
        //id from broadsign
        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        //name from broadsign
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
