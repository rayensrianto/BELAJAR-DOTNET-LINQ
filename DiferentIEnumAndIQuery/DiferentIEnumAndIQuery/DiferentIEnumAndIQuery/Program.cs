using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiferentIEnumAndIQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            EF_Demo_DBEntities dbContext = new EF_Demo_DBEntities();
            IEnumerable<Student> listStudents = dbContext.Students.Where(x => x.Gender == "Male");
            listStudents.Take(2);

            foreach (var std in listStudents)
            {
                Console.WriteLine(std.FirstName + " " + std.LastName);
            }

            Console.ReadKey();
        }
    }
}
