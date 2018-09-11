using System;
using System.Collections.Generic;

namespace MyLibraryConsole
{
    using DataMaster.DAO;
    using DataMaster.DbConnection;
    using DataMaster.Models;

    class Program
    {
        static void Main(string[] args)
        {
            SqlCommander.DatabaseServer = "den1.mssql4.gear.host";
            SqlCommander.DatabasUserId = "mylibrarydata";
            SqlCommander.DatabasePassword = "Fq9m?1a?5WG3";
            SqlCommander.DatabaseName = "mylibrarydata";

            Test();

        }


        private static void Test()
        {
            IEnumerable<ICreator> creators = new List<ICreator>();

            Console.WriteLine("Press Enter to Add Creator; type 'exit' to quit.");
    
            while (true)
            {

                var input = Console.ReadLine();

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    break;

                string name = "John Cossu";

                if (DateTime.Now.Second % 2 == 0)
                    name = "Christian Micklish";                

                ICreator newCreator = new Creator($"{name} _ {DateTime.Now}", "MyJson");

                newCreator = CreatorDao.Add(newCreator);

                creators = CreatorDao.Get();           

                foreach (ICreator creator in creators)
                    Console.WriteLine($"ID: {creator.Id} / Name: {creator.Name}");                

                Console.WriteLine(Environment.NewLine + Environment.NewLine);
            }
        }
    }
}
