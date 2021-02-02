using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace SEL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(StrToInt("1337"));
            int x = StrToInt("-1337");
            Console.WriteLine(x);
            AmountOfItems();
        }

        public static int StrToInt(string number)
        {
            int i = 0, result = 0;
            int num_len = number.Length;
            bool negative_number = false;

            if (i == num_len)
                return result;
            if (number[0] == '-')
            {
                negative_number = true;
                i++;
            }
            for (; i < num_len && char.IsDigit(number[i]); i++)
            {
                result = checked(result * 10 + (number[i] - '0'));
            }



            if (negative_number)
            {
                return result * -1;
            }
            return result;
        }

        public static void AmountOfItems()
        {
            int result = 0;
            var doc = XDocument.Load(@"C:\Users\Zeida\source\repos\SEL\XMLFile1.xml");
            var rootNodes = doc.Root.DescendantNodes().OfType<XElement>();

            List<string> words = new List<string>();
            words = doc.ToString().Split(' ').ToList();
            foreach (var x in words)
            {
                if (x == "<Item")
                    result += 1;
            }
            Console.WriteLine("Item occurs: {0} times.", result);
        }
    }  
}

