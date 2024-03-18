using DeliveriesRegistersModelos.Dominios;
using DeliveriesRegistersModelos.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveriesRegistersRepository
{
    public class DeliveryRespository
    {

        public DefaultResponse createDeliveryTruck(DeliveriesTruckInput deliveriesTruckInput)
        {
            try
            {
                DetailDelivery detailDeliveries = new DetailDelivery();
                detailDeliveries.id_product = deliveriesTruckInput.detailDeliveriesInput.id_product;
                detailDeliveries.registration_date = deliveriesTruckInput.detailDeliveriesInput.registration_date;
                detailDeliveries.deliver_date = deliveriesTruckInput.detailDeliveriesInput.deliver_date;
                detailDeliveries.price = deliveriesTruckInput.detailDeliveriesInput.price;
                detailDeliveries.guide_number = deliveriesTruckInput.detailDeliveriesInput.guide_number;
                detailDeliveries.id_discount = deliveriesTruckInput.detailDeliveriesInput.id_discount;
                detailDeliveries.value_discount = deliveriesTruckInput.detailDeliveriesInput.value_discount;
                detailDeliveries.amount_discount = deliveriesTruckInput.detailDeliveriesInput.amount_discount;
                detailDeliveries.total_price = deliveriesTruckInput.detailDeliveriesInput.total_price;
                
                DeliveryContext deliveryContext = new DeliveryContext();

                deliveryContext.detail_deliveries.Add(detailDeliveries);
                deliveryContext.SaveChanges();

                TruckDelivery truckDelivery = new TruckDelivery();
                truckDelivery.id_cellar = deliveriesTruckInput.id_cellar;
                truckDelivery.id_client = deliveriesTruckInput.id_client;
                truckDelivery.id_detail = detailDeliveries.id;
                truckDelivery.registration_number = deliveriesTruckInput.registration_number;

                deliveryContext.truck_deliveries.Add(truckDelivery);
                deliveryContext.SaveChanges();



                return new DefaultResponse() { code = 200, message = "ok" };
            }
            catch(Exception e)
            {
                return new DefaultResponse() { code = 400, message = e.Message };
            }

        }

        public DefaultResponse createDeliveryMaritime(DeliveriesMaritimeInput deliveriesMaritimeInput)
        {
            try
            {
                DetailDelivery detailDeliveries = new DetailDelivery();
                detailDeliveries.id_product = deliveriesMaritimeInput.detailDeliveriesInput.id_product;
                detailDeliveries.registration_date = deliveriesMaritimeInput.detailDeliveriesInput.registration_date;
                detailDeliveries.deliver_date = deliveriesMaritimeInput.detailDeliveriesInput.deliver_date;
                detailDeliveries.price = deliveriesMaritimeInput.detailDeliveriesInput.price;
                detailDeliveries.guide_number = deliveriesMaritimeInput.detailDeliveriesInput.guide_number;
                detailDeliveries.id_discount = deliveriesMaritimeInput.detailDeliveriesInput.id_discount;
                detailDeliveries.value_discount = deliveriesMaritimeInput.detailDeliveriesInput.value_discount;
                detailDeliveries.amount_discount = deliveriesMaritimeInput.detailDeliveriesInput.amount_discount;
                detailDeliveries.total_price = deliveriesMaritimeInput.detailDeliveriesInput.total_price;

                DeliveryContext deliveryContext = new DeliveryContext();

                deliveryContext.detail_deliveries.Add(detailDeliveries);
                deliveryContext.SaveChanges();

                MaritimeDelivery maritimeDelivery = new MaritimeDelivery();
                maritimeDelivery.id_port = deliveriesMaritimeInput.id_port;
                maritimeDelivery.id_client = deliveriesMaritimeInput.id_client;
                maritimeDelivery.id_detail = detailDeliveries.id;
                maritimeDelivery.fleet_number = deliveriesMaritimeInput.fleet_number;

                deliveryContext.maritime_deliveries.Add(maritimeDelivery);
                deliveryContext.SaveChanges();

                return new DefaultResponse() { code = 200, message = "ok" };
            }
            catch (Exception e)
            {
                return new DefaultResponse() { code = 400, message = e.Message };
            }

        }

        public IEnumerable<DataDeliveryResponse> findDeliveries()
        {

            DeliveryContext deliveryContext = new DeliveryContext();

            var serv = (from detail_deliveries in deliveryContext.detail_deliveries
                        join truck_deliveries in deliveryContext.truck_deliveries 
                            on detail_deliveries.id equals truck_deliveries.id_detail into truck_deliveriesSr
                            from td in truck_deliveriesSr.DefaultIfEmpty()
                        join maritime_deliveries in deliveryContext.maritime_deliveries 
                            on detail_deliveries.id equals maritime_deliveries.id_detail
                            into maritime_deliveriesSr
                            from md in maritime_deliveriesSr.DefaultIfEmpty()
                        join products in deliveryContext.products on detail_deliveries.id_product equals products.id
                        join clients in deliveryContext.clients 
                            on td.id_client equals clients.id
                            into clientsSr
                            from c in clientsSr.DefaultIfEmpty()
                        join clientsM in deliveryContext.clients
                            on md.id_client equals clientsM.id
                            into clienMts
                        from cm in clienMts.DefaultIfEmpty()
                        join cellars in deliveryContext.cellars on td.id_cellar equals cellars.id
                            into cellarsSr
                            from cell in cellarsSr.DefaultIfEmpty()
                        join ports in deliveryContext.ports on md.id_port equals ports.id
                            into portsSr
                            from p in portsSr.DefaultIfEmpty()
                        join cities in deliveryContext.cities on cell.id_city equals cities.id
                            into citiesSr
                            from cityC in citiesSr.DefaultIfEmpty()
                        join citiesP in deliveryContext.cities on p.id_city equals citiesP.id
                            into citiesPSr
                            from cityP in citiesPSr.DefaultIfEmpty()
                        select new DataDeliveryResponse
                        {
                            id = td.id ?? md.id ?? 0,
                            product = products.name,
                            client = c.name ?? cm.name,
                            place = cell.name ?? p.name,
                            city = cityC.name ?? cityP.name,
                            amount = detail_deliveries.amount,
                            value_discount = detail_deliveries.value_discount ?? 0,
                            value_product = products.value,
                            value_total = detail_deliveries.total_price
                        }).ToList();

            return (IEnumerable<DataDeliveryResponse>)serv;

        }

        public DataComboBoxResponse getDataComboBox()
        {
            DeliveryContext deliveryContext = new DeliveryContext();
            return new DataComboBoxResponse()
            {
                clients = deliveryContext.clients.ToList(),
                products = deliveryContext.products.ToList(),
                cellars = deliveryContext.cellars.ToList(),
                cities = deliveryContext.cities.ToList(),
                countries = deliveryContext.countries.ToList(),
                discounts = deliveryContext.discounts.ToList(),
                ports = deliveryContext.ports.ToList()
            };
        }
    }
}
