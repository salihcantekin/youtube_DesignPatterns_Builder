namespace DesignPatterns.BuilderPattern.Method1
{
    public class EmployeeM1
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }


        public override string ToString()
        {
            return $"{FirstName} {LastName} ({UserName})";
        }
    }
}