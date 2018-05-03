using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace StudentBL
{
    public class Student : Person
    {
        public int Grade;
        public Dictionary<string, List<int>> Marks;
        public Student(string Name, string Surname, string Patronomyc, int Age, int Grade) : base(Name, Surname, Patronomyc, Age)
        {
            this.Grade = Grade;
            this.Marks = new Dictionary<string, List<int>>();
            if (this.Grade == 9)
            {
                this.Marks.Add("Math", new List<int>());
                this.Marks.Add("Ukrainian_language", new List<int>());
                this.Marks.Add("Ukrainian_literature", new List<int>());
                this.Marks.Add("PE", new List<int>());
            }
        }

        public void ReadMarks()
        {
            DirectoryInfo dir = new DirectoryInfo("students/9/" + this.Name + ' ' + this.Surname + ' ' + this.Patronomyc + "/");
            FileInfo[] files = dir.GetFiles();
            foreach (var file in files)
            {
                using (StreamReader reader = new StreamReader(file.FullName))
                {
                    try
                    {
                        string[] markTempStrings = reader.ReadLine().Split(' ');
                        string subjectName = file.Name;
                        subjectName.Remove(subjectName.Length - 5, 4);
                        foreach (var markTempString in markTempStrings)
                        {
                            this.Marks[subjectName].Add(Convert.ToInt32(markTempString));
                        }
                    }
                    catch { }
                }
            }
        }

        public void AddMarks(string Subject, params int[] marks)
        {
            using (StreamWriter writer = new StreamWriter("students/9/" + this.Name + ' ' + this.Surname + ' ' + this.Patronomyc + "/" + Subject + ".txt"))
            {
                foreach (var mark in marks)
                {
                    this.Marks[Subject].Add(mark);
                }
                foreach (var mark in this.Marks[Subject])
                {
                    writer.Write(mark.ToString() + " ");
                }
            }
        }

        public void DeleteMarks(string Subject)
        {
            try
            {
                for (int i = this.Marks[Subject].Count; i >= 0; i--)
                {
                    this.Marks[Subject].RemoveAt(i);
                }
            }
            catch { }
            
            File.Delete("students/9/" + this.Name + ' ' + this.Surname + ' ' + this.Patronomyc + "/" + Subject + ".txt");
            File.Create("students/9/" + this.Name + ' ' + this.Surname + ' ' + this.Patronomyc + "/" + Subject + ".txt");
        }

        public static List<Student> ReadStudents(string fileName)
        {
            List<Student> students = new List<Student>();
            int N;
            using (StreamReader reader = new StreamReader("students/"+ fileName))
            {
                N = Convert.ToInt32(reader.ReadLine());
                for (int i = 0; i < N; i++)
                {
                    string[] buff = reader.ReadLine()?.Split(' ');
                    Student tempStudent = new Student(buff[0], buff[1], buff[2], Convert.ToInt32(buff[3]), Convert.ToInt32(buff[4]));
                    students.Add(tempStudent);
                }
            }
            return students;
        }

        public static void WriteStudents(List<Student> students, string fileName)
        {
            using (StreamWriter writer = new StreamWriter("students/" + fileName))
            {
                writer.WriteLine(students.Count);
                foreach (var student in students)
                {
                    writer.WriteLine(student.Name + ' ' + student.Surname + ' ' + student.Patronomyc + ' ' + student.Age + ' ' + student.Grade);
                }
            }

            foreach (var student in students)
            {
                Directory.CreateDirectory("students/9/" + student.Name + ' ' + student.Surname + ' ' + student.Patronomyc);
                using (StreamWriter writer = new StreamWriter("students/9/" + student.Name + ' ' + student.Surname + ' ' + student.Patronomyc + "/Math.txt"))
                {
                    foreach (var mark in student.Marks["Math"])
                    {
                        writer.Write(mark.ToString() + " ");
                    }
                }
                using (StreamWriter writer = new StreamWriter("students/9/" + student.Name + ' ' + student.Surname + ' ' + student.Patronomyc + "/Ukrainian_language.txt"))
                {
                    foreach (var mark in student.Marks["Ukrainian_language"])
                    {
                        writer.Write(mark.ToString() + " ");
                    }
                }
                using (StreamWriter writer = new StreamWriter("students/9/" + student.Name + ' ' + student.Surname + ' ' + student.Patronomyc + "/Ukrainian_literature.txt"))
                {
                    foreach (var mark in student.Marks["Ukrainian_literature"])
                    {
                        writer.Write(mark.ToString() + " ");
                    }
                }
                using (StreamWriter writer = new StreamWriter("students/9/" + student.Name + ' ' + student.Surname + ' ' + student.Patronomyc + "/PE.txt"))
                {
                    foreach (var mark in student.Marks["PE"])
                    {
                        writer.Write(mark.ToString() + " ");
                    }
                }
            }
        }
    }
}
