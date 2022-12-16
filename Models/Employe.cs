namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateOnly DateOfBrirth { get; set; } = new DateOnly();

        public bool Status { get; set; } = false;

        public int Salary { get; set; } = 0;

        public string Level { get; set; } = "Not specified";

        public string DepartmentName { get; set; } = "Not specified";

        public Employee() { }
        public Employee(int id, string firstName, string lastName, string email, bool status, int salary)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Status = status;
            Salary = salary;
        }

    }

}
