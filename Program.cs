using EmployeeManagementSystem.Data.Implementation;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.ProgramHelpers;

class Program
{
    public static void inputIntHandler()
    {
        Console.Clear();
        Console.WriteLine("\nPlease enter a number which represent your choice\n");
    }
    public static void searchMenu(EmployeeMethodRepository /*EmployeeQueryRepository*/ employee)
    {

        Console.WriteLine("\nChoose one of the following options:\n");
        Console.WriteLine("[ 1 ]- Search by ID");
        Console.WriteLine("[ 2 ]- Search by name (firstname or lastname)");
        Console.WriteLine("[ 3 ]- Search by status");
        Console.WriteLine("[ 4 ]- Search top employee by salary;");
        Console.WriteLine("[ 5 ]- Check if employee exists");

        Console.WriteLine("\n[ 0 ] Return to main menu\n");
        int searchOption;
        if (!int.TryParse(Console.ReadLine(), out searchOption))
        {
            inputIntHandler();
            searchMenu(employee);
        }
        switch (searchOption)
        {
            case 1:
                Console.Clear();
                Console.WriteLine("\nPlease, enter the ID of the employe (example: 1)\n");
                int ID;
                if (!int.TryParse(Console.ReadLine(), out ID))
                {
                    Console.WriteLine("\nPlease, enter a valid ID, try again\n");
                    searchMenu(employee);
                }
                var targetEmployee = employee.FindEmployeeById(ID);
                if (targetEmployee != null)
                {
                    Helper.Display(targetEmployee);
                }
                else
                {
                    Console.WriteLine("\nEmployee not found\n");
                    searchMenu(employee);
                }

                break;

            case 2:
                Console.Clear();
                Console.WriteLine("\nPlease, enter the name of the employe\n");
                string name = Console.ReadLine();
                IEnumerable<Employee> targetEmploye = employee.FindEmployeesByName(name);
                Helper.Display(targetEmploye);
                searchMenu(employee);
                break;

            case 3:
                Console.Clear();
                Console.WriteLine("\nWhich one of the following would you like to see?\n");
                Console.WriteLine("[ 1 ]- Working");
                Console.WriteLine("[ 2 ]- Out");

                Console.WriteLine("\n[ 0 ]- Go backward\n");

                int status;

                if (!int.TryParse(Console.ReadLine(), out status))
                {
                    inputIntHandler();
                }
                switch (status)
                {
                    case 1:
                        Helper.Display(employee.FindEmployeesByStatus(Helper.STATUS_WORKING));
                        searchMenu(employee);
                        break;
                    case 2:
                        Helper.Display(employee.FindEmployeesByStatus(Helper.STATUS_OUT));
                        searchMenu(employee);
                        break;
                    case 0:
                        Console.Clear();
                        searchMenu(employee);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("\nThe status choice were not valid. Please try again\n");
                        searchMenu(employee);
                        break;
                }



                break;


            case 4:
                Console.Clear();
                Console.WriteLine("\nPlease, enter the amount of the salary\n");
                int amount;
                if (!int.TryParse(Console.ReadLine(), out amount))
                {

                    Console.Clear();

                    Console.WriteLine("\nPlease enter a valid amount then try again\n");
                    searchMenu(employee);

                }
                Helper.Display(employee.FindTopEmployeesBySalary(amount));
                break;

            case 5:
                Console.Clear();
                Console.WriteLine("\nPlease, enter the ID of the employe to check\n");
                int checkID;
                if (!int.TryParse(Console.ReadLine(), out checkID))
                {
                    Console.WriteLine("\nThe ID is not a number, try again\n");
                    searchMenu(employee);
                }
                bool doesExists = employee.Exist(checkID);

                if (doesExists)
                {
                    Helper.Display(employee.FindEmployeeById(checkID));
                    searchMenu(employee);
                }
                else
                {

                    Console.WriteLine("\nEmploye does not exist\n");
                    searchMenu(employee);
                }

                break;

            case 0: return;
            default:
                inputIntHandler();
                searchMenu(employee);
                break;


        }



    }
    static public void Main()
    {

        EmployeeMethodRepository employee = new EmployeeMethodRepository();
        /*EmployeeQueryRepository employee = new EmployeeQueryRepository();*/
        List<Employee> employees = employee.GetEmployees();

        while (true)
        {
            Console.Title = "Employee Management - menu";
            int option;

            do
            {
                Console.WriteLine("\nChoose one of the following options:\n");

                Console.WriteLine("[ 1 ]- Display all");
                Console.WriteLine("[ 2 ]- Search employee");
                Console.WriteLine("[ 3 ]- Delete employee");
                Console.WriteLine("[ 0 ] Quit application\n");

            } while (!int.TryParse(Console.ReadLine(), out option) || option < 0);

            switch (option)
            {
                case 1:
                    Console.Clear();
                    Helper.Display(employees);
                    break;
                case 2:
                    Console.Clear();
                    searchMenu(employee);


                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("\n Please, enter the ID of the employee to delete:\n");
                    Console.WriteLine("[ 0 ] Return to main menu\n");
                    int deleteID;
                    if (!int.TryParse(Console.ReadLine(), out deleteID))
                    {

                        Console.WriteLine("\n Employee ID is not valid, try again\n");
                        Main();
                    }

                    if (option == 0)
                    {
                        return;
                    }
                    var deleted = employee.Delete(deleteID);
                    if (!deleted)
                    {
                        Console.WriteLine("\nEmployee not found\n");
                    }
                    else
                    {
                        Console.WriteLine("\nEmployee successfuly deleted\n");
                        Helper.Display(employees);
                    }
                    break;
                case 0:
                    Console.WriteLine("Bye");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Try again!!");
                    break;
            }
        }
    }
}
