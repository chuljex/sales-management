using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement.utils
{
    public class HandleTextInput
    {
        public string HandleStringInput()
        {
            string input = Console.ReadLine()!;
            while (input.Length < 1)
            {
                Console.WriteLine("Vui lòng không bỏ trống, nhập lại: ");
                input = Console.ReadLine()!;
            }
            return input;
        }
    }
}