namespace BuilderPattern.SecondMethod;

public abstract class BaseEmployeeBuilder : IEmployeeBuilder
{
    protected Employee Employee { get; set; }
    public BaseEmployeeBuilder()
    {
        Employee = new Employee();
    }

    public abstract void SetFullName(string fullName);
    public abstract void SetEmail(string email);
    // public abstract void SetUserName(string? userName);
    public abstract void SetUserName();
    public Employee BuildEmployee() => Employee;



}
