using FactoryMethodPattern.Models;
using FactoryMethodPattern.Models.Factory;
using FactoryMethodPattern.Services.OrderAcellerationService;
using FactoryMethodPattern.Services.PaymentService;
using FactoryMethodPattern.Services.ShippingService;

internal class Program
{
    private static void Main(string[] args)
    {
        //services
        IPaymentService paymentService = new BasicPaymentService();
        IShippingService shippingService = new FedexShippingService();
        OrderAccellerationService orderAccellerationService = new OrderAccellerationService();
        //factory dependencies
        IOnlineStoreFactory basicOnlineStoreFactory = new BasicOnlineStoreFactory(paymentService, shippingService);
        IOnlineStoreFactory fastOnlineStoreFactory = new FastOnlineStoreFactory(paymentService, shippingService, orderAccellerationService);


        // create store
        Console.Write("    🖊️ Enter your new online store's name: ");
        string storeName = Console.ReadLine();
        Thread.Sleep(1000);

        IOnlineStore store = basicOnlineStoreFactory.CreateOnlineStore(storeName);
        
        // or
        // IOnlineStore store = fastOnlineStoreFactory.CreateOnlineStore(storeName);

        Thread.Sleep(1000);
        // execute order 🎉
        store.OrderItem("Ramazan Altuntepe", "Framework Laptop 16gb 512gb ssd free OS(UBUNTU 22.04)");

        Console.ReadKey();

    }
}