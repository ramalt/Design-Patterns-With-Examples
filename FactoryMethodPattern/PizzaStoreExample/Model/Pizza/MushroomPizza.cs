using PizzaStoreExample.Model.Pizza;

namespace PizzaStoreExample.Model;

public class MushroomPizza : IPizza
{
    public MushroomPizza()
    {
        Console.WriteLine("     ✅ Order reveived.");
        Thread.Sleep(1000);
    }
    public void Bake()
    {
        Console.WriteLine("     🎛️ Mushroom pizza cooking...");
        Thread.Sleep(1000);
    }

    public void Cut()
    {
        Console.WriteLine("     🍴 Mushroom pizza slicing...");
        Thread.Sleep(1000);
    }

    public void Prepare()
    {
        Console.WriteLine("     ⏲️ Mushroom pizza preparing...");
        Thread.Sleep(1000);
    }
}
