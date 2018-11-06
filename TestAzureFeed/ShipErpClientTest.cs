using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rompr.ERP.SAP.Client.ShipErp;

namespace TestAzureFeed
{
    public class SapClientTest
    {
        public async Task TestStartedProduction()
        {
            var sapClient = new Rompr.ERP.SAP.Client.SapClient("Endpoint=sb://romprfusionsamples.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=BEUQywRJIJ7Y1o80MkAs9QnqCjXE1dcBIePVOpEUhD8=");
            await sapClient.StartedProductionOrderAsync("12345");
        }
    }
    public class ShipErpClientTest
    {
        //Replace with actual key and secret
        private const string ApiKey = "{REPLACE}";
        private const string ApiSecret = "{REPLACE}";
        private const string RequestUrl = "http://vhyetdp1ci.hec.yeti.com:50000/RESTAdapter/CC_REST_SNDR_CreateShipment/S4/SHIPERPCreateShipment";
        private const string SalesOrderTransactionId = "SO-0010025638";
        private const string ProductionOrderTransactionId = "000010";
        private const int Quantity = 1;
        public async Task TestLabel()
        {
            var provider =new ShipErpClient(ApiKey, ApiSecret, new Uri(RequestUrl));

            var items = new List<ShippingLabelRequest.SalesOrderProductionOrderItem>
            {
                new ShippingLabelRequest.SalesOrderProductionOrderItem(SalesOrderTransactionId, ProductionOrderTransactionId, Quantity),
            };

            var shippingLabelRequest = new ShippingLabelRequest(1, 2, 3, 4, items);

            var shippingLabelResponse = await provider.CreateLabel(shippingLabelRequest);
            Console.WriteLine(shippingLabelResponse.ShipmentId);
            Console.WriteLine(shippingLabelResponse.TrackingNumber);
        }
    }
}