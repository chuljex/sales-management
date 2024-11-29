using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleTables;

namespace SalesManagement.utils
{
    public class Table
    {
        public void Display<T>(List<T> items, List<string> title, string heading)
        {
            Console.WriteLine(heading);
            var table = new ConsoleTable(new ConsoleTableOptions
            {
                Columns = title,
                EnableCount = false
            });

            var properties = typeof(T).GetProperties();

            foreach (var item in items)
            {
                List<string> body = [];
                foreach (var property in properties)
                {
                    var value = property.GetValue(item)?.ToString();
                    body.Add(value);
                }
                table.AddRow(body.ToArray());
            }

            table.Write();
        }
    }
}