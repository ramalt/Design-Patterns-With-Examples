using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FactoryMethodPattern.Services.OrderAcellerationService;
using FactoryMethodPattern.Services.PaymentService;
using FactoryMethodPattern.Services.ShippingService;

namespace FactoryMethodPattern.Models;

public class FastOnlineStore : IOnlineStore
{
    public string Name { get; set; }

    private readonly IPaymentService _paymentService;
    private readonly IShippingService _shippingService;
    private readonly OrderAccellerationService _orderAccellerationService;

    public FastOnlineStore(string name, IPaymentService paymentService, IShippingService shippingService, OrderAccellerationService orderAccellerationService)
    {
        Name = name;
        _paymentService = paymentService;
        _shippingService = shippingService;
        _orderAccellerationService = orderAccellerationService;
    }

    public void OrderItem(string customerInfo, string item)
    {
        Console.WriteLine($" 🎯 '{Name}' received an order!");

        Console.WriteLine(" 🕔 Verifying order.");

        _orderAccellerationService.AccelerateOrder();

        Thread.Sleep(500);

        _paymentService.ProccesPayment(customerInfo);

        _shippingService.ProcessOrder(customerInfo, item);

        Console.WriteLine("✔️ Order complete.");
    }
}
