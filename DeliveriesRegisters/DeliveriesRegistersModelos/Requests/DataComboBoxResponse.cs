using DeliveriesRegistersModelos.Dominios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveriesRegistersModelos.Requests
{
    public class DataComboBoxResponse
    {
        public List<Clients> clients { get; set; }
        public List<Products> products { get; set; }
        public List<Countries> countries { get; set; }
        public List<Cities> cities { get; set; }
        public List<Ports> ports { get; set; }
        public List<Cellars> cellars { get; set; }
        public List<Discounts> discounts { get; set; }
    }
}
