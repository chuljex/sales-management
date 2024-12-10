using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement.utils
{
    public class HandleNumberInput
    {
        public decimal HandleDecimalInput(bool is_accept_blank)
        {
            string n = Console.ReadLine()!;
            if (is_accept_blank)
            {
                while (!decimal.TryParse(n, out _) && n.Length > 0)
                {
                    Console.Write("Xin hãy nhập số (có thể nhập số thập phân), nhập lại: ");
                    n = Console.ReadLine()!;
                }
            }
            else
            {
                while (!decimal.TryParse(n, out _))
                {
                    Console.Write("Xin hãy nhập số (có thể nhập số thập phân), nhập lại: ");
                    n = Console.ReadLine()!;
                }
            }
            return decimal.Parse(n);
        }
        public double HandleDoubleInput(bool is_accept_blank)
        {
            string n = Console.ReadLine()!;
            if (is_accept_blank)
            {
                while (!double.TryParse(n, out _) && n.Length > 0)
                {
                    Console.Write("Xin hãy nhập số (có thể nhập số thập phân), nhập lại: ");
                    n = Console.ReadLine()!;
                }
            }
            else
            {
                while (!double.TryParse(n, out _))
                {
                    Console.Write("Xin hãy nhập số (có thể nhập số thập phân), nhập lại: ");
                    n = Console.ReadLine()!;
                }
            }
            return double.Parse(n);
        }
        public int HandleIntInput(bool is_accept_blank)
        {
            string n = Console.ReadLine()!;
            if (is_accept_blank)
            {
                while (!int.TryParse(n, out _) && n.Length > 0)
                {
                    Console.Write("Xin hãy nhập số nguyên, nhập lại: ");
                    n = Console.ReadLine()!;
                }
            }
            else
            {
                while (!int.TryParse(n, out _))
                {
                    Console.Write("Xin hãy nhập số nguyên, nhập lại: ");
                    n = Console.ReadLine()!;
                }
            }
            return int.Parse(n);
        }
    }
}