namespace DesignPatterns.BuilderPattern.Method1
{
    public class EmployeeBuilderM1
    {
        private EmployeeM1 employee {get;set;}

        public EmployeeBuilderM1()
        {
            employee = new EmployeeM1();
        }

        public EmployeeBuilderM1 SetFullName(string fullName)
        {
            // validations

            var arr = fullName.Split(' ');

            employee.FirstName = arr[0];
            employee.LastName = arr[1];

            return this;
        }

        public EmployeeBuilderM1 SetEmailAddress(string emailAddress)
        {
            // Email address validation
            employee.EmailAddress = emailAddress;

            return this;
        }

        public EmployeeBuilderM1 SetUserName(string userName)
        {
            employee.UserName = userName;

            return this;
        }


        public EmployeeM1 BuildEmployee()
        {
            return employee;
        }
    }
}