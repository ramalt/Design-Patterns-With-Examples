using PizzaStoreExample.Model.Pizza;

namespace PizzaStoreExample.Model.Store;

public abstract class PizzaStoreBase
{
    // set pizza type from child classes.
    protected abstract IPizza CreatePizza(string type);
    //
    public IPizza OrderPizza(string type)
    {
        IPizza pizza = CreatePizza(type);

        pizza.Prepare();
        pizza.Bake();
        pizza.Cut();

        return pizza;
    }
}
