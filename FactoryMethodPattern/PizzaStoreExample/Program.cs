using PizzaStoreExample.Model.Store;

internal class Program
{
    private static void Main(string[] args)
    {
        PizzaStoreBase ankaraPizzaStore = new AnkaraPizzaStore();
        PizzaStoreBase izmirPizzaStore = new IzmirPizzaStore();


        ankaraPizzaStore.OrderPizza("mushroom");
        ankaraPizzaStore.OrderPizza("Cheese");
        izmirPizzaStore.OrderPizza("chEese");
        izmirPizzaStore.OrderPizza("MushRoom");

    }
}