using System;
using System.Collections.Generic;
using System.Linq;

class Program 
{
	static void Main(string[] args)
	{
		//datasource
		List<int> integerList = new List<int>() 
		{
			1,2,3,4,5,6,7,8,9,10
		};

		//linq query using mixed syntax
		var MixedSyntax = (from obj in integerList
							where obj > 5
							select obj).Sum();

		//execution
		Console.Write("Sum is : " + MixedSyntax);
	}
}