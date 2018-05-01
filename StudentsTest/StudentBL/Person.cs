using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentBL
{
    public class Person
    {
        public string Name, Surname, Patronomyc;
        public int Age;

        public Person(string Name, string Surname, string Patronomyc, int Age)
        {
            this.Age = Age;
            this.Name = Name;
            this.Surname = Surname;
            this.Patronomyc = Patronomyc;
        }
    }
}
