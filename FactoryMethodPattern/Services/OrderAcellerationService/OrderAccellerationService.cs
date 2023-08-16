namespace FactoryMethodPattern.Services.OrderAcellerationService;

public class OrderAccellerationService
{
    public void AccelerateOrder()
    {
        Console.WriteLine("     🏃‍♂️ Accelerating order...");
        Thread.Sleep(1000);
    }
}
