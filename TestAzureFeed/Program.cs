using System.Threading.Tasks;

namespace TestAzureFeed
{
    class Program
    {
        static void Main(string[] args)
        {
//            var sapClientTest = new SapClientTest();
//
//            sapClientTest.TestStartedProduction().Wait();

            var shipErpClientTest = new ShipErpClientTest();
            shipErpClientTest.TestLabel().Wait();
        }
    }
}
