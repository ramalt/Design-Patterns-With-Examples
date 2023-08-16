namespace FactoryMethodPattern.Services.ShippingService;

public class FedexShippingService : IShippingService
{
    public void ProcessOrder(string customerInfo, string item)
    {
         Console.WriteLine($"    ✅ Processing order from {customerInfo} for 1 {item} Fedex shipping.");
         Thread.Sleep(1000);
    }
}
