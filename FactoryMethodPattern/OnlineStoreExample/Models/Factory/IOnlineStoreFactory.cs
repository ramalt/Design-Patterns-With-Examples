namespace FactoryMethodPattern.Models.Factory;

public interface IOnlineStoreFactory
{
    public IOnlineStore CreateOnlineStore(string name);
}
