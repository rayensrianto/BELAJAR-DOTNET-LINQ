using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
	static void Main(string[] args)
	{
		// query "select *" dengan query syntax
		List<Employee> querySyntax = (from emp in Employee.GetEmployees()
									  select emp).ToList();
		foreach (Employee emp in querySyntax)
		{
			Console.WriteLine("ID : "+ emp.ID + " Name : "+ emp.FirstName + " " + emp.LastName);
		}

		Console.WriteLine();
		
		// query "select *" dengan method syntax
		IEnumerable<Employee> methodSyntax = Employee.GetEmployees().ToList();
		foreach (Employee emp in methodSyntax)
		{
			Console.WriteLine("ID : "+ emp.ID + " Name : "+ emp.FirstName + " " + emp.LastName);
		}

		Console.WriteLine();

		SelectSingleProperty();
		Console.WriteLine();

		SelectMultipleProperty();
		Console.WriteLine();


	}

	static void SelectSingleProperty()
	{
		//query syntax
		List<int> querySyntax = (from emp in Employee.GetEmployees()
								 select emp.ID).ToList();

		foreach (var id in querySyntax)
		{
			Console.WriteLine("ID : " + id);
		}

		Console.WriteLine();

		//method syntax
		IEnumerable<int> methodSyntax = Employee.GetEmployees().Select(emp => emp.ID);
		foreach (var id in methodSyntax)
		{
			Console.WriteLine("ID : " + id);
		}
	}

	static void SelectMultipleProperty()
	{
		//query syntax
		IEnumerable<Employee> selectQuery = (from emps in Employee.GetEmployees()
											 select new Employee()
											 {
											 	FirstName = emps.FirstName,
											 	LastName = emps.LastName,
											 	Salary = emps.Salary
											 });

		foreach (Employee emp in selectQuery)
		{
			Console.WriteLine(" Name : "+ emp.FirstName + " " + emp.LastName + " Salary : "+ emp.Salary);
		}

		Console.WriteLine();

		//method syntax
		List<Employee> methodQuery = Employee.GetEmployees().
									 Select(emps => new Employee()
									 {
									 	FirstName = emps.FirstName,
									 	LastName = emps.LastName,
									 	Salary = emps.Salary
									 }).ToList();

		foreach (Employee emp in methodQuery)
		{
			Console.WriteLine(" Name : "+ emp.FirstName + " " + emp.LastName + " Salary : "+ emp.Salary);
		}
	}
}

public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }
        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee {ID = 101, FirstName = "Preety", LastName = "Tiwary", Salary = 60000 },
                new Employee {ID = 102, FirstName = "Priyanka", LastName = "Dewangan", Salary = 70000 },
                new Employee {ID = 103, FirstName = "Hina", LastName = "Sharma", Salary = 80000 },
                new Employee {ID = 104, FirstName = "Anurag", LastName = "Mohanty", Salary = 90000 },
                new Employee {ID = 105, FirstName = "Sambit", LastName = "Satapathy", Salary = 100000 },
                new Employee {ID = 106, FirstName = "Sushanta", LastName = "Jena", Salary = 160000 }
            };
            return employees;
        }
    }

