namespace PizzaStoreExample.Model.Pizza;

public class PizzaFactory
{
    private readonly string _pizzaType;
    public PizzaFactory(string type)
    {
        _pizzaType = type.ToUpper();
    }

    public IPizza createPizza()
    {
        
        return _pizzaType switch 
        {
            "CHEESE" => new CheesePizza(),
            "MUSHROOM" => new MushroomPizza(),
            _ => throw new ArgumentException("  ❌ Invalid type, i am sorry :/")
        };
    }
}
