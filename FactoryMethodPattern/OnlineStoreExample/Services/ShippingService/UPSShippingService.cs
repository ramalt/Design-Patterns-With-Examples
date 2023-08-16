namespace FactoryMethodPattern.Services.ShippingService;

public class UPSShippingService : IShippingService
{
    public void ProcessOrder(string customerInfo, string item)
    {
        Console.WriteLine($"✅ Processing order from {customerInfo} for 1 {item} UPS shipping.");
    }
}
