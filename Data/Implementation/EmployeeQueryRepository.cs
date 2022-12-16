using EmployeeManagementSystem.Data.Interfaces;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Data.Implementation
{
    public class EmployeeQueryRepository : IEmployeeRepository
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
            bool isDeleted = false;
            var targetEmployee = from e in Employees
                                 where e.Id == id
                                 select e;
            foreach (var e in targetEmployee.ToList())
            {
                isDeleted = Employees.Remove(e);
            }
            return isDeleted;
        }

        public bool Exist(int id)
        {
            bool exists = false;

            var targetEmploye = from e in Employees
                                where e.Id == id
                                select e;
            foreach (Employee e in targetEmploye)
            {
                exists = Employees.Contains(e);
            }
            return exists;
        }

        public Employee FindEmployeeById(int id)
        {
            Employee employee = new Employee();
            var targetEmploye = from e in Employees
                                where e.Id == id
                                select e;
            foreach (var e in targetEmploye)
            {
                employee = e;
            }
            return employee;
        }

        public IEnumerable<Employee> FindEmployeesByName(string name)
        {

            var targetEmploye = from e in Employees
                                where e.FirstName.ToLower().Equals(name) || e.LastName.ToLower().Equals(name)
                                select e;
            return targetEmploye;
        }

        public IEnumerable<Employee> FindEmployeesByStatus(bool status)
        {
            var targetEmploye = from e in Employees
                                where e.Status == status
                                select e;
            return targetEmploye;
        }

        public IEnumerable<Employee> FindTopEmployeesBySalary(int size)
        {
            var targetEmploye = from e in Employees
                                where e.Salary >= size
                                orderby e.Salary descending
                                select e;
            return targetEmploye;
        }
    }
}
