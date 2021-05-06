using System;
using System.Collections.Generic;
using System.Linq;

class Program 
{
	static void Main(string[] args) 
	{
		//data source
		List<int> integerList = new List<int>()
		{
			1,2,3,4,5,6,7,8,9,10
		};

		//LINQ Query using method syntax
		var MethodSyntax = integerList.Where(obj => obj > 5).ToList();

		//execution
		foreach(var item in MethodSyntax)
		{
			Console.Write(item + " ");
		}
	}
}