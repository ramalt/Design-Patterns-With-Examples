using PizzaStoreExample.Model.Pizza;

namespace PizzaStoreExample.Model.Store;

public class AnkaraPizzaStore : PizzaStoreBase
{
    protected override IPizza CreatePizza(string type) => new PizzaFactory(type).createPizza();
}
