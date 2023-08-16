using PizzaStoreExample.Model.Pizza;

namespace PizzaStoreExample.Model;

public class CheesePizza : IPizza
{
    public CheesePizza()
    {
        Console.WriteLine("     ✅ Order reveived.");
        Thread.Sleep(1000);
    }
    public void Bake()
    {
        Console.WriteLine("     🎛️ Cheese pizza cooking...");
        Thread.Sleep(1000);
    }

    public void Cut()
    {
        Console.WriteLine("     🍴 Cheese pizza slicing...");
        Thread.Sleep(1000);
    }

    public void Prepare()
    {
        Console.WriteLine("     ⏲️ Cheese pizza preparing...");
        Thread.Sleep(1000);
    }
}
