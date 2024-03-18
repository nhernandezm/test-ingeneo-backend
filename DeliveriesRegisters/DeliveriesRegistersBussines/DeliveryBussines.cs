using DeliveriesRegistersModelos.Dominios;
using DeliveriesRegistersModelos.Requests;
using DeliveriesRegistersRepository;
using System;
using System.Collections.Generic;

namespace DeliveriesRegistersBussines
{
    public class DeliveryBussines
    {

        public DefaultResponse createDeliveryTruck(DeliveriesTruckInput deliveriesTruckInput)
        {
            DeliveryRespository deliveryContext = new DeliveryRespository();
            return deliveryContext.createDeliveryTruck(deliveriesTruckInput);
        }

        public DefaultResponse createDeliveryMaritime(DeliveriesMaritimeInput deliveriesMaritimeInput)
        {
            DeliveryRespository deliveryContext = new DeliveryRespository();
            return deliveryContext.createDeliveryMaritime(deliveriesMaritimeInput);
        }

        public IEnumerable<DataDeliveryResponse> findDeliveries()
        {
            DeliveryRespository deliveryContext = new DeliveryRespository();
            return deliveryContext.findDeliveries();
        }

        public DataComboBoxResponse getDataComboBox()
        {
            DeliveryRespository deliveryContext = new DeliveryRespository();
            return deliveryContext.getDataComboBox();
        }
    }
}
