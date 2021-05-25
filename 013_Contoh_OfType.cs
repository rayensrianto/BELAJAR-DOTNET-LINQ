using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> dataSource = new List<object>()
            {
                "Tom", "Jerry", 130, 321, "Prince", "Jack", 99
            };

            List<int> intData = dataSource.OfType<int>().ToList();
            
            foreach (var item in intData)
            {
                Console.WriteLine(item);
            }

            //sample OfType with condition
            List<int> intDataFiltered = dataSource
                .OfType<int>()
                .Where(num => num > 100)
                .ToList();

            foreach (var items in intDataFiltered)
            {
                Console.WriteLine(items);
            }
        }
    }
}