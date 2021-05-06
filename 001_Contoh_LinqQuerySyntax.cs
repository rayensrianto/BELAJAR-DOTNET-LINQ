using System;
using System.Collections.Generic;
using System.Linq;

class Program {
	static void Main(string[] args)
	{
		//data source
		List<int> integerList = new List<int>() 
		{
			1,2,3,4,5,6,7,8,9,10
		};

		//query syntax
		var QuerySyntax = from obj in integerList
							where obj > 5
							select obj;

		//execution
		foreach(var item in QuerySyntax) 
		{
			Console.Write(item + " ");
		}

	}
}