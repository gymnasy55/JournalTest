using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentBL;

namespace StudentsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "students.txt";
            List<Student> students = Student.ReadStudents(fileName);
            while (true)
            {
                Console.Write("Выберите, что хотите сделать (1 - добавить, 0 - удалить список, -1 - выход из программы): ");
                int mode = -1;
                mode = Convert.ToInt32(Console.ReadLine());
                if (mode == 0)
                {
                    for (int i = students.Count - 1; i >= 0; i--) students.RemoveAt(i);
                }
                else if (mode == 1)
                {
                    Console.WriteLine("Напишите кого хотите добавить в формате:\nИмя Фамилия Отчество Возраст Класс");
                    string[] temp = Console.ReadLine().Split(' ');
                    Student tempStudent = new Student(temp[0], temp[1], temp[2], Convert.ToInt32(temp[3]), Convert.ToInt32(temp[4]));
                    students.Add(tempStudent);
                }
                else if (mode == -1) break;
            }
            Student.WriteStudents(students, fileName);
        }
    }
}
