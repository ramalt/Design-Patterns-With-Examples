using FactoryMethodPattern.Services.OrderAcellerationService;
using FactoryMethodPattern.Services.PaymentService;
using FactoryMethodPattern.Services.ShippingService;

namespace FactoryMethodPattern.Models.Factory;

public class FastOnlineStoreFactory : IOnlineStoreFactory
{
    private readonly IPaymentService _paymentService;
    private readonly IShippingService _shippingService;
    private readonly OrderAccellerationService _orderAccellerationService;

    public FastOnlineStoreFactory(IPaymentService paymentService, IShippingService shippingService, OrderAccellerationService orderAccellerationService)
    {
        _paymentService = paymentService;
        _shippingService = shippingService;
        _orderAccellerationService = orderAccellerationService;
    }
    public IOnlineStore CreateOnlineStore(string name) => new FastOnlineStore(name, _paymentService, _shippingService, _orderAccellerationService);
}
