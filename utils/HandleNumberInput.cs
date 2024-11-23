using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement.utils
{
    public class HandleNumberInput
    {
        public double HandleDoubleInput()
        {
            string n = Console.ReadLine()!;
            while (n.Length < 1 || !double.TryParse(n, out _))
            {
                Console.WriteLine("Chỉ được nhập số, không nhập chữ và bỏ trống, nhập lại: ");
                n = Console.ReadLine()!;
            }
            return double.Parse(n);
        }
        public int HandleIntInput()
        {
            string n = Console.ReadLine()!;
            while (n.Length < 1 || !int.TryParse(n, out _))
            {
                Console.WriteLine("Chỉ được nhập số, không nhập chữ và bỏ trống, nhập lại: ");
                n = Console.ReadLine()!;
            }
            return int.Parse(n);
        }
    }
}