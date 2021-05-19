using System;
using System.Collections.Generic;
using System.Linq;

class Program 
{
    static void Main(string[] args)
    {
        List<int> intList = new List<int> {1,2,3,4,5,6,7,8,9,10};

        //method syntax
        IEnumerable<int> filteredData = intList.Where(num => CheckNum(num));

        foreach (int item in filteredData)
        {
            Console.WriteLine(item);
        }
    }

    public static bool CheckNum(int num)
    {
        if (num > 5) {
            return true;
        }
        else {
            return false;
        }
    }
}