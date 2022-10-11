using System.Text;
using DesignPatterns.BuilderPattern.Method1;
using DesignPatterns.BuilderPattern.Method2;

var sb = new StringBuilder();

sb.Append("salih").Append(" ").Append("Cantekin");
sb.Append(" Cantekin");

var fullname = sb.ToString();


var eb = new EndpointBuilder("https://localhost");

   eb
    .Append("api")
    .Append("v1")
    .Append("user")
    .AppendParam("id", "5")
    .AppendParam("username", "salih");

var url = eb.Build();

//System.Console.WriteLine("Final Url:" + url);


var empBuilder = new EmployeeBuilderM1();

var employee = empBuilder
    .SetFullName("Salih Cantekin")
    .SetUserName("salihcantekin")
    .SetEmailAddress("salihcantekin@gmail.com")
    .BuildEmployee();

// System.Console.WriteLine("M1 Employee FirstName: " + employee.FirstName);


var emp =  GenerateEmployee("salih cantekin", "salihcantekin@gmail.com", 0);
System.Console.WriteLine("Email Address: " + emp.EmailAddress);
/*
IEmployeeBuilderM2 employeeBuilder = new InternalEmployeeBuilder();

employeeBuilder.SetEmailAddress("salihcantekin@gmail.com");
employeeBuilder.SetFullName("Salih Cantekin");

var emp = employeeBuilder.BuildEmployee();

System.Console.WriteLine("Email Address: " + emp.EmailAddress);
*/


EmployeeM2 GenerateEmployee(string fullName, string emailAddress, int empType)
{
    IEmployeeBuilderM2 employeeBuilder;
    if (empType == 0)
        employeeBuilder = new InternalEmployeeBuilder();
    else
        employeeBuilder = new ExternalEmployeeBuilder();

    employeeBuilder.SetFullName(fullName);
    employeeBuilder.SetEmailAddress(emailAddress);

    return employeeBuilder.BuildEmployee();
}