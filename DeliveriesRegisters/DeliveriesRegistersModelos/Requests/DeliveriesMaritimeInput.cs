using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveriesRegistersModelos.Requests
{
    public class DeliveriesMaritimeInput
    {
        public int? id { get; set; }
        public string fleet_number { get; set; }
        public int? id_port { get; set; }
        public int? id_client { get; set; }
        public double? total_price { get; set; }
        public DetailDeliveriesInput detailDeliveriesInput { get; set; }
    }
}
