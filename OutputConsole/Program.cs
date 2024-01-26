using System;
using System.Text;
using HRMSystem.DAOs;
using HRMSystem.Models;

namespace OutputConsole
{
    public class Program
    {
        private static HRMSystemEntities db = new HRMSystemEntities();

        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            Console.WriteLine($"Number of position(s) in database = {PositionTypeDAO.Count}");
            Console.WriteLine();
            Console.WriteLine($"Number of work type(s) in database = {WorkTypeDAO.Count}");
        }
    }
}
