using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveriesRegistersModelos.Dominios
{
    public class TruckDelivery
    {
        public int? id { get; set; }
        public string registration_number { get; set; }
        public int? id_cellar { get; set; }
        public int? id_client { get; set; }
        public int? id_detail { get; set; }
        public double? total_price { get; set; }
    }
}
