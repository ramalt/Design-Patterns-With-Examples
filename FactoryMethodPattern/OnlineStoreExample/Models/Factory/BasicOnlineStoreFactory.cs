using FactoryMethodPattern.Services.PaymentService;
using FactoryMethodPattern.Services.ShippingService;

namespace FactoryMethodPattern.Models.Factory;

public class BasicOnlineStoreFactory : IOnlineStoreFactory
{
    private readonly IPaymentService _paymentService;
    private readonly IShippingService _shippingService;

    public BasicOnlineStoreFactory(IPaymentService paymentService, IShippingService shippingService)
    {
        _paymentService = paymentService;
        _shippingService = shippingService;
    }
    public IOnlineStore CreateOnlineStore(string name) => new BasicOnlineStore(name, _paymentService, _shippingService);
}
