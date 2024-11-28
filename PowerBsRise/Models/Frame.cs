using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerBsRise.Models
{
    public class Frame
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
        private Size _size;
        public Size Size
        {
            get { return _size; }
            set { _size = value; }
        }
        //represents the first value in the size so X see google docs for more information
        private int _xAxis;

        public int XAxis
        {
            get { return _xAxis; }
            set { _xAxis = value; }
        }
        private int _yAxis;

        public int YAxis
        {
            get { return _yAxis; }
            set { _yAxis = value; }
        }
        private int _zAxis;

        public int ZAxis
        {
            get { return _zAxis; }
            set { _zAxis = value; }
        }
    }
}
