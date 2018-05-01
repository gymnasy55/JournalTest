using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentBL
{
    public class Teacher : Person
    {
        public int Experience;
        public string Subject;
        public Teacher(string Name, string Surname, string Patronomyc, int Age, string Subject, int Experience) : base(Name, Surname, Patronomyc, Age)
        {
            this.Experience = Experience;
            this.Subject = Subject;
        }
    }
}
