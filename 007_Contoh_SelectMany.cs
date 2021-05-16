using System;
using System.Collections.Generic;
using System.Linq;

class Program 
{
	static void Main(String[] args)
	{
		Sample1();
		Sample2();
	}

	static void Sample1()
	{
		List<string> nameList = new List<string>()
		{
			"Srimahi", "BKR"
		};
		
		IEnumerable<char> methodSyntax = nameList.SelectMany(x => x);

		foreach (char item in methodSyntax)
		{
			Console.Write(item + " ");
		}
	}

	static void Sample2()
	{
		//using method syntax
		List<string> MethodSyntax = Student.GetStudents().SelectMany(std => std.Programming).ToList();

		foreach (string item in MethodSyntax)
		{
			Console.WriteLine(item);
		}
	}
}

class Student 
{
	public int ID { get; set; }
	public string Name { get; set; }
	public string Email { get; set; }
	public List<string> Programming { get; set; }

	public static List<Student> GetStudents()
	{
		return new List<Student>()
		{
			new Student() 
			{
				ID = 1, 
				Name = "James", 
				Email = "james@j.com", 
				Programming = new List<string>()
				{
					"C#", "C", "C++"
				}
			},
			new Student() 
			{
				ID = 2, 
				Name = "Trump", 
				Email = "trump@j.com", 
				Programming = new List<string>()
				{
					"Cobol", "C", "Java"
				}
			},
			new Student() 
			{
				ID = 3, 
				Name = "Ryan", 
				Email = "ryan@j.com", 
				Programming = new List<string>()
				{
					"C#", "Java", "PHP"
				}
			}
		};
	}
}