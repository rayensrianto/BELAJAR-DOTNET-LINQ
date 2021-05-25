using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqDemo 
{
    class program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sample 1");
            Sample1();
            Console.WriteLine("=================================================");

            Console.WriteLine("Sample 2");
            Sample2();
            Console.WriteLine("=================================================");

            Console.WriteLine("Sample 3");
            Sample3();
            Console.WriteLine("=================================================");

        }
        static void Sample1()
        {
            //menampilkan data karyawan yang memiliki gaji lebih dari 5000 (where with 1 condition)
            var methodSyntax = Employee.GetEmployees()
                .Where(emp => emp.Salary > 5000);
            
            foreach (var item in methodSyntax)
            {
                Console.WriteLine("Name: " +item.Name+ ", Salary: " +item.Salary+ ", Gender: " +item.Gender);

                if (item.Technology != null && item.Technology.Count() > 0)
                {
                    Console.Write("Technology : ");
                    foreach (var techno in item.Technology)
                    {
                        Console.Write(techno + " ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Technology Not Available");
                }
            }
        }

        static void Sample2()
        {
            //where dengan multiple conditions
            var methodSyntax = Employee.GetEmployees()
                .Where(emp => emp.Salary > 5000 && emp.Gender == "Male");
            
            foreach (var item in methodSyntax)
            {
                Console.WriteLine("Name: " +item.Name+ ", Salary: " +item.Salary+ ", Gender: " +item.Gender);

                if (item.Technology != null && item.Technology.Count() > 0)
                {
                    Console.Write("Technology : ");
                    foreach (var techno in item.Technology)
                    {
                        Console.Write(techno + " ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Technology Not Available");
                }
            }
        }

        static void Sample3()
        {
            //menampilkan employee yang memiliki gaji lebih dari 500000 dan ber gender male, bersama dengan index position nya ke anonymous type
            var methodSyntax = Employee.GetEmployees()
                .Select((Data, index) => new {
                    employee = Data,
                    Index = index
                })
                .Where(emp => emp.employee.Salary >= 500000 && emp.employee.Gender == "Male")
                .Select(emp => new {
                    EmployeeName = emp.employee.Name,
                    Gender = emp.employee.Gender,
                    Salary = emp.employee.Salary,
                    IndexPosition = emp.Index
                })
                .ToList();

            foreach (var item in methodSyntax)
            {
                Console.WriteLine("Employee Name = " +item.EmployeeName+ ", Gender = " +item.Gender+ ", Salary = " +item.Salary+ ", Index Position = " +item.IndexPosition);
            }
        }
    }

    #region datasource
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }
        public List<string> Technology { get; set; }

        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>()
            {
               new Employee {
                ID = 101, Name = "Preety", Gender = "Female", Salary = 60000,
                    Technology = new List < string > () {
                    "C#",
                    "Jave",
                    "C++"
                    }
                },
                new Employee {
                ID = 102, Name = "Priyanka", Gender = "Female", Salary = 50000,
                    Technology = new List < string > () {
                    "WCF",
                    "SQL Server",
                    "C#"
                    }
                },
                new Employee {
                ID = 103, Name = "Hina", Gender = "Female", Salary = 40000,
                    Technology = new List < string > () {
                    "MVC",
                    "Jave",
                    "LINQ"
                    }
                },
                new Employee {
                ID = 104, Name = "Anurag", Gender = "Male", Salary = 450000
                },
                new Employee {
                ID = 105, Name = "Sambit", Gender = "Male", Salary = 550000
                },
                new Employee {
                ID = 106, Name = "Sushanta", Gender = "Male", Salary = 700000,
                    Technology = new List < string > () {
                    "ADO.NET",
                    "C#",
                    "LINQ"
                    }
            }
            };

            return employees;
        }
    }
}
    #endregion
