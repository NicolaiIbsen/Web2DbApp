using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Web2DbAppNet2.Entities;

namespace Web2DbAppNet2.DataAccess
{
    public class DataRepository
    {
        private Executor executor;

        public DataRepository()
        {
            Executor = new Executor();
        }

        public Executor Executor { get => executor; set => executor = value; }

        public List<Person> GetAll()
        {
            List<Person> persons = new List<Person>();
            string sql = "SELECT * FROM Persons";
            DataSet set = Executor.Execute(sql);
            DataTable table = set.Tables[0];
            foreach (DataRow row in table.Rows)
            {
                string firstname = (string)row["Firstname"];
                string lastname = (string)row["Lastname"];
                string title = (string)row["Title"];
                persons.Add(new Person(firstname, lastname, title));
            }
            return persons;
        }
        public void Save(List<Person> persons)
        {
            foreach (Person p in persons)
            {
                string sql = $"INSERT INTO Persons " +
                    $"(Firstname, Lastname, Title) " +
                    $"VALUES ('{p.Firstname}', '{p.Lastname}', '{p.TitelOfCourtesey}')";
                Executor.Execute(sql);
            }            
        }
    }
}
