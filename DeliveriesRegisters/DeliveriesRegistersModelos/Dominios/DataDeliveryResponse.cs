using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveriesRegistersModelos.Dominios
{
    public class DataDeliveryResponse
    {
        public int id { get; set; }
        public string product { get; set; }
        public string client { get; set; }
        public string place { get; set; }
        public string city { get; set; }
        public int? amount { get; set; }
        public double? value_total { get; set; }
        public decimal? value_product { get; set; }
        public double? value_discount { get; set; }

    }
}
