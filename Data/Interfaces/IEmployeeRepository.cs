using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Data.Interfaces
{
    public interface IEmployeeRepository
    {

        Employee FindEmployeeById(int id);

        IEnumerable<Employee> FindEmployeesByName(string name);

        IEnumerable<Employee> FindTopEmployeesBySalary(int size);
        IEnumerable<Employee> FindEmployeesByStatus(bool status);

        bool Exist(int id);
        bool Delete(int id);

    }
}
