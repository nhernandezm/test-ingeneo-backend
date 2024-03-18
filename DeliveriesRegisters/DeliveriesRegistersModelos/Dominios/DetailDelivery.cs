using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveriesRegistersModelos.Dominios
{
    public class DetailDelivery
    {
        public int id { get; set; }
        public int id_product { get; set; }
        public int amount { get; set; }
        public double? price { get; set; }
        public DateTime registration_date { get; set; }
        public DateTime deliver_date { get; set; }
        public string guide_number { get; set; }
        public int? id_discount { get; set; }
        public double? value_discount { get; set; }
        public double? amount_discount { get; set; }
        public double? total_price { get; set; }
    }
}
