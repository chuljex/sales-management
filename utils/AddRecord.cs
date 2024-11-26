using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesManagement.utils;

namespace SalesManagement.utils
{
    public class AddRecord
    {
        private readonly HandleNumberInput _numberInputHandler = new HandleNumberInput();
        private readonly HandleTextInput _stringInputHandler = new HandleTextInput();
        public List<string> Add(string title, List<string> dataField, List<string> dataType)
        {
            List<string> data = [];
            for (int i = 0; i < dataField.Count; i++)
            {
                var numberInput = 0.0;
                var decimalInput = 0m;
                var stringInput = "";
                Console.WriteLine($"Nhập {dataField[i]} {title}: ");
                if (dataType[i] == "int")
                {
                    numberInput = _numberInputHandler.HandleIntInput();
                    data.Add(numberInput.ToString());
                }
                if (dataType[i] == "double")
                {
                    numberInput = _numberInputHandler.HandleDoubleInput();
                    data.Add(numberInput.ToString());
                }
                if (dataType[i] == "decimal")
                {
                    decimalInput = _numberInputHandler.HandleDecimalInput();
                    data.Add(decimalInput.ToString());
                }
                if (dataType[i] == "string")
                {
                    stringInput = _stringInputHandler.HandleStringInput();
                    data.Add(stringInput.ToString());
                }
            }
            return data;
        }
    }
}