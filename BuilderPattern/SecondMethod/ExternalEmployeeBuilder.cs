using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuilderPattern.SecondMethod;

public class ExternalEmployeeBuilder : BaseEmployeeBuilder
{
    private string _username;
    public ExternalEmployeeBuilder(string userName)
    {
        _username = userName;
    }
    public override void SetEmail(string email)
    {
        Employee.Email = email;
    }

    public override void SetFullName(string fullName)
    {
        string[] arr = fullName.Split(' ');
        Employee.FirstName = arr[0];
        Employee.LastName = arr[1].ToUpper();
    }

    public override void SetUserName()
    {
        Employee.UserName = _username;
    }
}
