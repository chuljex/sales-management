using System;
using System.Text;
using SalesManagement.Controllers;
using SalesManagement.Models;
using SalesManagement.Views;
using SalesManagement.Data;
using ConsoleTables;

namespace SalesManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.UTF8;

            var context = new SalesContext();
            var view = new MainView(context);

            view.DisplayMenu();
        }
    }
}
