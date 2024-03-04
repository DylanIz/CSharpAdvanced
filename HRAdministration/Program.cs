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
            IEmployee teacher1 = new Teacher()
            {
                Id = 1,
                FirstName = "Jim",
                LastName = "Smith",
                Salary = 54000
            };

            employees.Add(teacher1);

            IEmployee teacher2 = new Teacher()
            {
                Id = 2,
                FirstName = "Ron",
                LastName = "Black",
                Salary = 34332
            };

            employees.Add(teacher2);

            IEmployee headOfDepartment = new HeadOfDepartment()
            {
                Id = 3,
                FirstName = "Peter",
                LastName = "Parker",
                Salary = 76000
            };

            employees.Add(headOfDepartment);

            IEmployee vicePrincipal = new VicePrincipal()
            {
                Id = 4,
                FirstName = "Tony",
                LastName = "Stark",
                Salary = 87774
            };

            employees.Add(vicePrincipal);

            IEmployee principal = new Principal()
            {
                Id = 5,
                FirstName = "Paul",
                LastName = "Jones",
                Salary = 98377
            };

            employees.Add(principal);
        }
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
