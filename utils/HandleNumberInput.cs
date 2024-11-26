using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement.utils
{
    public class HandleNumberInput
    {
        public decimal HandleDecimalInput()
        {
            string n = Console.ReadLine()!;
            while (n.Length < 1 || !decimal.TryParse(n, out _))
            {
                Console.WriteLine("Xin hãy nhập số (có thể nhập số thập phân), nhập lại: ");
                n = Console.ReadLine()!;
            }
            return decimal.Parse(n);
        }
        public double HandleDoubleInput()
        {
            string n = Console.ReadLine()!;
            while (n.Length < 1 || !double.TryParse(n, out _))
            {
                Console.WriteLine("Xin hãy nhập số (có thể nhập số thập phân), nhập lại: ");
                n = Console.ReadLine()!;
            }
            return double.Parse(n);
        }
        public int HandleIntInput()
        {
            string n = Console.ReadLine()!;
            while (n.Length < 1 || !int.TryParse(n, out _))
            {
                Console.WriteLine("Xin hãy nhập số nguyên, nhập lại: ");
                n = Console.ReadLine()!;
            }
            return int.Parse(n);
        }
    }
}