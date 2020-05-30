using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoCatalog.Models
{
    public class Log
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int VehicleID { get; set; }
        public string Comments { get; set; }
    }
}
