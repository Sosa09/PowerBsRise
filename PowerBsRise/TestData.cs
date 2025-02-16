using PowerBsRise.Models;
using PowerBsRise.Services;
using System;
using System.Collections.Generic;
namespace PowerBsRise
{
    public class TestData
    {
        public DataHandler<DisplayUnit> DisplayUnits;
        public DataHandler<Host> HostObjects;
        public DataHandler<OperatingHour> OperatingHours;        
        public TestData()
        {
            DisplayUnits = new DataHandler<DisplayUnit>();
            HostObjects = new DataHandler<Host>();
            OperatingHours = new DataHandler<OperatingHour>();
            GeneratingDisplayUnits(DisplayUnits);
        }
        private void GeneratingDisplayUnits(DataHandler<DisplayUnit> du)
        {
            DisplayUnit displayUnit = new DisplayUnit()
            {
                Name = "BE-RO-VIL-P001",
                Address = "Havenstraat 17, 1800 Vilvoorde BELGIUM",
                DayParts = new List<DayPart>(), //just leave it empty for the test.
                DisplayTypeResolution = new DisplayTypeResolution(), //empty
                Geolocation = "lat/lon",
                Hosts = HostObjects.GetAll(),
                ID = 0,
                Zip = 1800
            };
            du.Add(displayUnit);
        }
        public void FetchDisplayUnits(DataHandler<DisplayUnit> du)
        {
            Console.WriteLine("SHOWING DISPLAY UNITS");
            du.GetAll().ForEach(x => { Console.WriteLine(x.ToString()); });
        }
    }
}
