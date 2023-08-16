using PizzaStoreExample.Model.Pizza;

namespace PizzaStoreExample.Model.Store;

public class IzmirPizzaStore : PizzaStoreBase
{
    protected override IPizza CreatePizza(string type) => new PizzaFactory(type).createPizza();

}
