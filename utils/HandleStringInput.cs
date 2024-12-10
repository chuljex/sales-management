using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement.utils
{
    public class HandleTextInput
    {
        public string HandleStringInput(bool is_accept_blank)
        {
            string input = Console.ReadLine()!;
            if (!is_accept_blank)
            {
                while (input.Length < 1)
                {
                    Console.Write("Vui lòng không bỏ trống, nhập lại: ");
                    input = Console.ReadLine()!;
                }
            }
            return input;
        }
    }
}