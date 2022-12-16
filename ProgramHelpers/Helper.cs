using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.ProgramHelpers
{
    class Helper
    {

        public const bool STATUS_WORKING = true;
        public const bool STATUS_OUT = false;
        const string WORKING = "Working";
        const string OUT = "Out";

        public static void Display(List<Employee> employees)
        {
            foreach (Employee employee in employees)
            {
                Console.WriteLine("ID: " + employee.Id + ", Name: " + employee.FirstName + " " + employee.LastName
                    + ", Email: " + employee.Email + ", status: " + (employee.Status ? WORKING : OUT));
            }
        }

        public static void Display(Employee employee)
        {
            Console.WriteLine("Name: " + employee.FirstName + " " + employee.LastName
                + ", Email : " + employee.Email + ", status: " + (employee.Status ? WORKING : OUT));
        }


        public static void Display(IEnumerable<Employee> enumerable)
        {
            foreach (Employee employee in enumerable)
            {
                Console.WriteLine("Name: " + employee.FirstName + " " + employee.LastName
                    + ", Email : " + employee.Email + ", status: " + (employee.Status ? WORKING : OUT));
            }
        }

        public static bool convertStatus(int status)
        {
            if (status == 1)
            {
                return STATUS_WORKING;
            }
            else
            {
                return STATUS_OUT;
            }
        }
    }
}
