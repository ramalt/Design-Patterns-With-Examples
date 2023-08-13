using BuilderPattern.SecondMethod;


internal class Program
{
    private static void Main(string[] args)
    {
        // internal Employee 
        IEmployeeBuilder internalEmployeeBuilder = new InternalEmployeeBuilder();

        internalEmployeeBuilder.SetFullName("Ramazan Altuntepe");
        internalEmployeeBuilder.SetEmail("ramazanalltuntepe@gmail.com");
        internalEmployeeBuilder.SetUserName();

        var employee = internalEmployeeBuilder.BuildEmployee();

        Console.WriteLine($"First Name: {employee.FirstName}, Last Name: {employee.LastName}, Username: {employee.UserName}, Created Email: {employee.Email}");

        // External Employee
        IEmployeeBuilder externalEmployeeBuilder = new ExternalEmployeeBuilder("johndoe");

        externalEmployeeBuilder.SetFullName("John Doe");
        externalEmployeeBuilder.SetEmail("johndoe@gmail.com");
        externalEmployeeBuilder.SetUserName();

        var externalEmployee = externalEmployeeBuilder.BuildEmployee();

        Console.WriteLine($"First Name: {externalEmployee.FirstName}, Last Name: {externalEmployee.LastName}, Username: {externalEmployee.UserName}, Created Email: {externalEmployee.Email}");



        Console.ReadKey();
    }
}