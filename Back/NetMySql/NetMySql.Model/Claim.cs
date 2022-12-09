using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMySql.Model
{
    public class Claim
    {
        public int IdClaim { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int IdVehicle { get; set; }
    }
}
