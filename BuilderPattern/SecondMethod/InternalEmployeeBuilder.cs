namespace BuilderPattern.SecondMethod;

public class InternalEmployeeBuilder : BaseEmployeeBuilder
{
    public override void SetEmail(string email)
    {
        string[] arr = email.Split('@');
        Employee.Email = arr[0] + "@github.com";
    }

    public override void SetFullName(string fullName)
    {
        string[] arr = fullName.Split(' ');
        Employee.FirstName = arr[0];
        Employee.LastName = arr[1].ToUpper();
    }

    public override void SetUserName()
    {
        string firstName = Employee.FirstName.ToLower();
        string lastName = Employee.LastName.ToLower();

        Random random = new Random();
        string num = random.Next(0, 101).ToString();
        string internalUserName = $"{firstName}_{lastName}_{num}";
        Employee.UserName = internalUserName;

    }

}
