using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web2DbAppNet2.Entities;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Web2DbAppNet2.Services
{
    public class MockDataProvider
    {
        private string url = "https://randomuser.me/api/?results=";
        private string include = "";

        public List<Person> GetPeople(int amount)
        {
            List<Person> persons = new List<Person>();
            WebClient wc = new WebClient();
            string respone = wc.DownloadString(url + amount + include);
            JObject jsonRespone = JObject.Parse(respone);

            for (int i = 0; i < amount; i++)
            {
                JObject name = (JObject)jsonRespone["results"][i]["name"];
                JToken firstname = name["first"];
                JToken lastname = name["last"];
                JToken titleOfCourtesy = name["title"];
                persons.Add(new Person(firstname.ToString(), lastname.ToString(), titleOfCourtesy.ToString()));
            }
            return persons;
        }
    }
}
