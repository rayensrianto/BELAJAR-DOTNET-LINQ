using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqDemo 
{
    class program
    {
        static void Main(string[] args)
        {
            List<int> intList = new List<int> {1,2,3,4,5,6,7,8,9,10};

            //method syntax
            IEnumerable<int> data = intList.Where(num => num > 5).ToList();

            foreach (int number in data)
            {
                Console.WriteLine(number);
            }
        }
    }
}