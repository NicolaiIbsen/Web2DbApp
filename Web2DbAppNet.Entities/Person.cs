using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web2DbAppNet2.Entities
{
    public class Person
    {
        #region Fields
        private string firstname;
        private string lastname;
        private string titelOfCourtesey;
        #endregion


        #region Constructors
        public Person(string firstname, string lastname, string titelOfCourtesey)
        {
            Firstname = firstname;
            Lastname = lastname;
            TitelOfCourtesey = titelOfCourtesey;
        }
        public Person(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
        #endregion


        #region Properties
        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string TitelOfCourtesey { get => titelOfCourtesey; set => titelOfCourtesey = value; }
        #endregion


        #region Methods
        public override string ToString()
        {
            return $"{titelOfCourtesey} {firstname} {lastname}";
        }
        #endregion
    }
}
