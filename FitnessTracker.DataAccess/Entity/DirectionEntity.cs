using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.DataAccess.Entity
{
    public class DirectionEntity
    {
        public int Id { get; set; }        
        public string DirectionName { get; set; }
        public string Street { get; set; }
        public int StreetId { get; set; }
        public int Distance { get; set; }
        public double Duration { get; set; }
        public double Speed { get; set; }
        public string Date { get; set; }
        public UserEntity Owner { get; set; }     
    }
}
