namespace FactoryMethodPattern.Services.PaymentService;

public class BasicPaymentService : IPaymentService
{
    public void ProccesPayment(string customerInfo)
    {
        Console.WriteLine($"    ⏳ Processing payment for {customerInfo}");
        Thread.Sleep(1000);
    }
}
