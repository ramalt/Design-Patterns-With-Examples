namespace SingletonPattern.Model;

public class CountryProvider
{
    private static CountryProvider? instance = null;

    //eğer instance null ise yeni instance yarat, değilse instance dön.
    public static CountryProvider Instance => instance ?? new CountryProvider();

    private new List<Country> Countries { get; set; }

    //CountryProvider shouldnt be instantiated.
    private CountryProvider()
    {
        Countries = new List<Country>()
        {
            new Country() { Name = "New Zeland",},
            new Country() { Name = "Algeria",},
            new Country() { Name = "Montenegro",},
            new Country() { Name = "Turkey",}
        };
    }
    public async Task<List<Country>> GetCountries() => Countries;
}
