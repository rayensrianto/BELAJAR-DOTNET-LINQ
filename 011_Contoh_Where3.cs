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
            var OddNumberWithIndexPosition = intList.Select((num, index) => new
                                            {
                                               Numbers = num,
                                               IndexPositions = index 
                                            })
                                            .Where(x => x.Numbers % 2 != 0)
                                            .Select(data => new 
                                            {
                                                Number = data.Numbers,
                                                IndexPosition = data.IndexPositions
                                            });

            foreach (var item in OddNumberWithIndexPosition)
            {
                Console.WriteLine("Index Position : "+ item.IndexPosition +" Number : "+item.Number);                
            }
        }
    }
}