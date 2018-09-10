using DataMaster.DAO;
using DataMaster.DbConnection;
using DataMaster.Models;
using System.Collections.Generic;

namespace MyLibraryConsole
{
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

            CreatorDao dao = new CreatorDao();

            creators = dao.GetCreators();

            // Set Breakpoint here...
        }
    }
}
