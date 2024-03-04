using HRAdinAPI;


public enum EmployeeType
{
    Teacher,
    HeadOfDepartment,
    VicePrincipal,
    Principal,
}

class Program
{
    public static void Main(string[] args)
    {
        decimal totalSalaries = 0;
        List<IEmployee> employees = new List<IEmployee>();

        SeedData(employees);


        Console.WriteLine($"Total Salaries (inc bonus): {employees.Sum(e => e.Salary)}");

        Console.ReadKey();

        static void SeedData(List<IEmployee> employees)
        {
            IEmployee teacher1 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 1, "Jim", "Smith", 54000);
            employees.Add(teacher1);

            IEmployee teacher2 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 2, "Ron", "Black", 34332);
            employees.Add(teacher2);

            IEmployee headOfDepartment = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadOfDepartment, 3, "Peter", "Parker", 76000);
            employees.Add(headOfDepartment);

            IEmployee vicePrincipal = EmployeeFactory.GetEmployeeInstance(EmployeeType.VicePrincipal, 4, "Tony", "Stark", 87774);
            employees.Add(vicePrincipal);

            IEmployee principal = EmployeeFactory.GetEmployeeInstance(EmployeeType.VicePrincipal, 5, "Paul", "Jones", 98377);
            employees.Add(principal);
        }
    }


    public class Teacher : EmployeeBase
    {
        public override decimal Salary => base.Salary + base.Salary * 0.02m;
    }

    public class HeadOfDepartment : EmployeeBase
    {
        public override decimal Salary => base.Salary + base.Salary * 0.05m;
    }

    public class VicePrincipal : EmployeeBase
    {
        public override decimal Salary => base.Salary + base.Salary * 0.1m;
    }

    public class Principal : EmployeeBase
    {
        public override decimal Salary => base.Salary + base.Salary * 0.2m;
    }

    public static class EmployeeFactory
    {
        public static IEmployee GetEmployeeInstance(EmployeeType employeeType, int id, string firstName,
            string lastName, decimal salary)
        {
            IEmployee employee = null!;

            switch (employeeType)
            {
                case EmployeeType.Teacher:
                    employee = new Teacher { Id = id, FirstName = firstName, LastName = lastName, Salary = salary };
                    break;
                case EmployeeType.HeadOfDepartment:
                    employee = new HeadOfDepartment { Id = id, FirstName = firstName, LastName = lastName, Salary = salary };
                    break;
                case EmployeeType.VicePrincipal:
                    employee = new VicePrincipal { Id = id, FirstName = firstName, LastName = lastName, Salary = salary };
                    break;
                case EmployeeType.Principal:
                    employee = new Principal { Id = id, FirstName = firstName, LastName = lastName, Salary = salary };
                    break;
            }

            return employee;
        }

        
    }

}