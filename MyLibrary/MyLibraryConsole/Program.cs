using System;
using System.Collections.Generic;

namespace MyLibraryConsole
{
    using DataMaster.DAO;
    using DataMaster.DbConnection;
    using DataMaster.DTO;
    using DataMaster.Models;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            SqlCommander.DatabaseServer = "den1.mssql4.gear.host";
            SqlCommander.DatabasUserId = "mylibrarydata";
            SqlCommander.DatabasePassword = "Fq9m?1a?5WG3";
            SqlCommander.DatabaseName = "mylibrarydata";

            TestItems();
        }

        private static void TestRelations()
        {
            IDataParameter parameter = new SqlParameter("@ItemID", 3);

            ItemRelationshipsDto dto = ItemDao.GetRelations(parameter);

            Console.WriteLine($"Here is the relationships for: {Environment.NewLine + Environment.NewLine} {dto.Item.Name} {Environment.NewLine + Environment.NewLine}");

            foreach (IItemRelation relation in dto.Relations)
            {
                if (relation.ItemOneId == dto.Item.Id)
                {
                    IItem relatedItem = dto.Items.FirstOrDefault(item => item.Id == relation.ItemTwoId);

                    Console.WriteLine($"{dto.Item.Name} has a downstream dependency to {relatedItem.Name}.");
                }
                else
                {
                    IItem relatedItem = dto.Items.FirstOrDefault(item => item.Id == relation.ItemOneId);

                    Console.WriteLine($"{dto.Item.Name} has a upstream dependency to {relatedItem.Name}.");
                }
            }

            Console.Read();
        }

        private static void TestCreators()
        {
            IEnumerable<ICreator> creators = new List<ICreator>();
    
            while (true)
            {

                Console.WriteLine("Press Enter to Add Creator; type 'exit' to quit.");

                var input = Console.ReadLine();

                Console.Clear();

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

        private static void TestItems()
        {

            while (true)
            {
                Console.WriteLine("Enter any number between 1 and 13; type 'exit' to quit.");

                string input = Console.ReadLine();

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    break;

                int id = Convert.ToInt32(input);

                IDataParameter parameter = new SqlParameter("@ItemID", id);
                IItem selectedItem = ItemDao.Get(parameter);

                Console.WriteLine($"You have selected {selectedItem.Name} {Environment.NewLine}");

                ItemRelationshipsDto dto = ItemDao.GetRelations(parameter);

                foreach (IItemRelation relation in dto.Relations)
                {
                    if (relation.ItemOneId == selectedItem.Id)
                    {
                        IItem relatedItem = dto.Items.FirstOrDefault(item => item.Id == relation.ItemTwoId);

                        Console.WriteLine($"{selectedItem.Name} has a downstream dependency to {relatedItem.Name}.");
                    }
                    else
                    {
                        IItem relatedItem = dto.Items.FirstOrDefault(item => item.Id == relation.ItemOneId);

                        Console.WriteLine($"{selectedItem.Name} has a upstream dependency to {relatedItem.Name}.");
                    }
                }

                Console.WriteLine(Environment.NewLine + Environment.NewLine + "----------------------------------------------------------");
            }
        }    
            
    }
}
