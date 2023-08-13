using SingletonPattern.Model;

internal class Program
{
    private static async Task Main(string[] args)
    {
        // CountryProvider countryProvier = new CountryProvider();

        List<Country> countries = await CountryProvider.Instance.GetCountries();

        /**
        ** Output:
            New Zeland
            Algeria
            Montenegro
            Turkey
        */
        foreach (var country in countries)
        {
            Console.WriteLine(country.Name);
        }

    }
}