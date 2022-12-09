using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMySql.Model
{
    public class Vehicle
    {
        public int IdVehicle { get; set; }
        public string Brand { get; set; }
        public string Vin { get; set; }
        public string Color { get; set; }
        public string Year { get; set; }
        public int IdOwner { get; set; }

    }
}
