using System;

namespace PowerBsRise.Models
{
    public class OperatingHour
    {
        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _minuteMask;
        public string MinuteMask
        {
            get { return _minuteMask; }
        }
        private DateTime _startTime;

        public DateTime StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }
        private DateTime _endTime;

        public DateTime EndTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }
        private DateTime _dayOfWeek;

        public DateTime DayOfWeek
        {
            get { return _dayOfWeek; }
            set { _dayOfWeek = value; }
        }
    }
}
