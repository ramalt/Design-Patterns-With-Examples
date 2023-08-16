namespace FactoryMethodPattern.Services.ShippingService;

public interface IShippingService
{
    void ProcessOrder(string customerInfo, string item);
}
