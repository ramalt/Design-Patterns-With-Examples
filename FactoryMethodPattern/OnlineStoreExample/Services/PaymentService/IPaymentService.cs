using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryMethodPattern.Services.PaymentService;

public interface IPaymentService
{
    public void ProccesPayment(string customerInfo);
}
