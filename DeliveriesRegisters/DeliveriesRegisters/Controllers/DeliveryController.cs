using DeliveriesRegistersBussines;
using DeliveriesRegistersModelos.Dominios;
using DeliveriesRegistersModelos.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DeliveriesRegisters.Controllers
{
    [Route("api/delivery")]
    public class DeliveryController : Controller
    {

        [HttpPost("create/truck")]
        public DefaultResponse createDeliveryTruck([FromBody] DeliveriesTruckInput deliveriesTruckInput)
        {
            DeliveryBussines deliveryBussines = new DeliveryBussines();
            return deliveryBussines.createDeliveryTruck(deliveriesTruckInput);
        }

        [HttpPost("create/maritime")]
        public DefaultResponse createDeliveryMaritime([FromBody] DeliveriesMaritimeInput deliveriesMaritimeInput)
        {
            DeliveryBussines deliveryBussines = new DeliveryBussines();
            return deliveryBussines.createDeliveryMaritime(deliveriesMaritimeInput);
        }

        [HttpGet]
        public IEnumerable<DataDeliveryResponse> list()
        {
            DeliveryBussines deliveryBussines = new DeliveryBussines();
            return deliveryBussines.findDeliveries();
        }

        [HttpGet("datacombobox")]
        public DataComboBoxResponse getDataCombo()
        {
            DeliveryBussines deliveryBussines = new DeliveryBussines();
            return deliveryBussines.getDataComboBox();
        }
    }
}
