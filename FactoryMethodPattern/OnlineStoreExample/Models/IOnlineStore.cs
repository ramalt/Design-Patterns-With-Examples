namespace FactoryMethodPattern.Models;

public interface IOnlineStore
{
    public string Name { get; set; }

    void OrderItem(string customerInfo, string item);
}
