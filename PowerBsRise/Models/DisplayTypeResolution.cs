namespace PowerBsRise.Models
{
    public class DisplayTypeResolution
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
        private DisplayOrientation _orientation;
        public DisplayOrientation Orientation
        {
            get { return _orientation; }
            set { _orientation = value; }
        }
    }
}
