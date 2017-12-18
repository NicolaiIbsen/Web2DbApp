using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Web2DbAppNet2.DataAccess;
using Web2DbAppNet2.Entities;
using Web2DbAppNet2.Services;

namespace Web2DbAppNet2.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            MockDataProvider dataProvider = new MockDataProvider();
            DataRepository repo = new DataRepository();
            repo.Executor.Execute("dbo.MyProcedure", 2);

            List<Person> persons = dataProvider.GetPeople(9);
            repo.Save(persons);

            List<Person> personFromDatabase = repo.GetAll();
            foreach (Person p in personFromDatabase)
            {
                Console.WriteLine(p);
            }
            Console.ReadKey();
        }
    }
}
