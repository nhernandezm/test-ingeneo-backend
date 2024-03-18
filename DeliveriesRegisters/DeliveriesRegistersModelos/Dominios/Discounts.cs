using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveriesRegistersModelos.Dominios
{
    public class Discounts
    {
        public int id
        {
            get; set;
        }
        public string name
        {
            get; set;
        }
        public int min_value
        {
            get; set;
        }
        public int max_value
        {
            get; set;
        }
        public int percent
        {
            get; set;
        }
    }
}
