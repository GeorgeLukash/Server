using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.DataModel.Direction
{
    public class CreateDirectionModel
    {        
        public string DirectionName { get; set; }
        public string Street { get; set; }
        public int StreetId { get; set; }
        public int Distance { get; set; }
        public double Duration { get; set; }
        public double Speed { get; set; }
        public string Date { get; set; }       
    }
}