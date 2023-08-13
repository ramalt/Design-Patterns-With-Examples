namespace BuilderPattern.SecondMethod;

public interface IEmployeeBuilder
{
    public void SetFullName(string fullName);
    public void SetEmail(string email);
    // public void SetUserName(string? userName = null);
    public void SetUserName();
    public Employee BuildEmployee();
}
