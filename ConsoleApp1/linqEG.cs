using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOEG
{
    class CollLINQeg
    {
        public static void Main()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var result = (from i in numbers
                          where i % 2 == 0
                          select i).ToList();
            Console.WriteLine("Even Numbers");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            List<string> names = new List<string>();
            names.Add("Tom");
            names.Add("Teddy");
            names.Add("Rick");
            names.Add("Maria");
            names.Add("Mona");
            var data = (from i in names
                        where i.StartsWith('M')
                        select i).ToList();

            foreach (var item in data)
            {
                Console.WriteLine(item);
            }
        }
    }
}
