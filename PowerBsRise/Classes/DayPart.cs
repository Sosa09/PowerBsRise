using System.Collections.Generic;

namespace PowerBsRise.Models
{
    public class DayPart
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
        private List<Frame> _frames;

        public List<Frame> Frames
        {
            get { return _frames; }
            set { _frames = value; }
        }
        private List<OperatingHour> _operatingHours;

        public List<OperatingHour> OperatingHours
        {
            get { return _operatingHours; }
            set { _operatingHours = value; }
        }
    }
}
