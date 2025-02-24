using System.Collections.Generic;

namespace PowerBsRise.Models
{
    public class DisplayUnit : ICommonPropertyResource
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        private List<Host> _hosts;

        public List<Host> Hosts
        {
            get { return _hosts; }
            set { _hosts = value; }
        }
        private List<DayPart> _dayParts;

        public List<DayPart> DayParts
        {
            get { return _dayParts; }
            set { _dayParts = value; }
        }
        private DisplayTypeResolution _displayTypeResolution;

        public DisplayTypeResolution DisplayTypeResolution
        {
            get { return _displayTypeResolution; }
            set { _displayTypeResolution = value; }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _address;

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        private int _zip;

        public int Zip
        {
            get { return _zip; }
            set { _zip = value; }
        }
        private string _geolocation;
        public string Geolocation
        {
            get { return _geolocation; }
            set { _geolocation = value; }
        }

        public override string ToString()
        {
            return 
                $"------------------------------------\n" +
                $"{Name}:\n" +
                $"ID:\t{ID}\n" +
                $"Address: {Address}\n";
        }
    }
}
