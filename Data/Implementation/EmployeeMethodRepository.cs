using EmployeeManagementSystem.Data.Interfaces;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Data.Implementation
{
    public class EmployeeMethodRepository : IEmployeeRepository
    {
        public List<Employee> Employees = new List<Employee>()
        {
            new Employee(1, "John", "Doe", "john.doe@test.com", true, 100),
            new Employee(2, "John", "Travolta", "john.travolta@test.com" , false, 200),
            new Employee(3, "John", "Wick", "john.Wick@test.com", false, 500),
            new Employee(4, "Johnny", "Depp", "johnny.depp@test.com" , true, 400),
            new Employee(5, "Johnny", "Sins", "johnny.sins@test.com", true, 100),
            new Employee(6, "Johnny", "Haliday", "johnny.Haliday@test.com", true, 1300),
            new Employee(7, "Johnny", "Holiday", "johnny.Holiday@test.com", true, 1500),
            new Employee(8, "Bruce", "Lee", "bruce.@test.com", false, 300),
            new Employee(9, "Bruce", "Campbell", "bruce.campbell@test.com", false, 200),
            new Employee(10, "Bruce", "Willis", "bruce.willis@test.com", false, 100),
        };

        public List<Employee> GetEmployees() => Employees;

        public bool Delete(int id)
        {
            var employee = Employees.Find(e => e.Id == id);
            return Employees.Remove(employee);
        }

        public bool Exist(int id) => Employees.Exists(e => e.Id == id);

        public Employee FindEmployeeById(int id)
        {
            return Employees.Find(e => e.Id == id);

        }

        public IEnumerable<Employee> FindEmployeesByName(string name)
        {
            return Employees.Where(e => e.FirstName.ToLower().Equals(name.ToLower()) ||
            e.LastName.ToLower().Equals(name.ToLower()));
        }

        public IEnumerable<Employee> FindEmployeesByStatus(bool status)
        {
            return Employees.FindAll(e => e.Status == status);
        }

        public IEnumerable<Employee> FindTopEmployeesBySalary(int size)
        {
            return Employees.Where(e => e.Salary >= size);

        }

    }
}
