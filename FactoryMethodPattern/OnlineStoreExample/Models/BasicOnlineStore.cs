using FactoryMethodPattern.Services.PaymentService;
using FactoryMethodPattern.Services.ShippingService;

namespace FactoryMethodPattern.Models;

public class BasicOnlineStore : IOnlineStore
{
    public string Name { get; set; }

    private readonly IPaymentService _paymentService;
    private readonly IShippingService _shippingService;

    public BasicOnlineStore(string name, IPaymentService paymentService, IShippingService shippingService)
    {
        Name = name;
        _paymentService = paymentService;
        _shippingService = shippingService;

        Thread.Sleep(1000);
        Console.WriteLine($"    🥳 created your Online store named {Name}");
    }


    public void OrderItem(string customerInfo, string item)
    {
        Console.WriteLine($"    🎯 '{Name}' received an order!");
        Thread.Sleep(1000);

        Console.WriteLine("    🕔 Verifying order.");

        Thread.Sleep(1000);

        _paymentService.ProccesPayment(customerInfo);

        _shippingService.ProcessOrder(customerInfo, item);

        Console.WriteLine("    ✔️ Order complete.");
        Thread.Sleep(1000);
    }
}
