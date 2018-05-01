using System;
using System.Collections.Generic;
using System.IO;
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
            string[] subjects = {"Math", "Ukrainian language", "Ukrainian literature", "PE"};
            List<Student> students = Student.ReadStudents(fileName);
            while (true)
            {
                Console.Write("Выберите, что хотите сделать (2 - выбрать ученика, 1 - добавить, 0 - удалить список, -1 - выход из программы): ");
                int mode = -1;
                mode = Convert.ToInt32(Console.ReadLine());
                if (mode == 0)
                {
                    for (int i = students.Count - 1; i >= 0; i--) students.RemoveAt(i);
                    DirectoryInfo mainDir = new DirectoryInfo("students/9/");
                    DirectoryInfo[] dirs = mainDir.GetDirectories();
                    foreach (var dir in dirs)
                    {
                        FileInfo[] files = dir.GetFiles();
                        foreach (var file in files)
                        {
                            file.Delete();
                        }
                        dir.Delete();
                    }
                }
                else if (mode == 1)
                {
                    Console.WriteLine("Напишите кого хотите добавить в формате:\nИмя Фамилия Отчество Возраст Класс");
                    string[] temp = Console.ReadLine().Split(' ');
                    Student tempStudent = new Student(temp[0], temp[1], temp[2], Convert.ToInt32(temp[3]), Convert.ToInt32(temp[4]));
                    students.Add(tempStudent);
                }
                else if (mode == -1) break;
                else if (mode == 2)
                {
                    for (int i = 0; i < students.Count; i++)
                    {
                        Console.WriteLine((i + 1).ToString() + "-" + students[i].Name + " " + students[i].Surname + " " + students[i].Patronomyc + " " + students[i].Age.ToString() + " " + students[i].Grade.ToString());
                    }
                    Console.Write("Выберите номер студента: ");
                    int NumberOfStudent = Convert.ToInt32(Console.ReadLine());
                    NumberOfStudent--;
                    Console.Write("Выберите режим работы с учеником (1 - работа с оценками, 0 - удалить студента): ");
                    int markMode = Convert.ToInt32(Console.ReadLine());
                    if (markMode == 0)
                    {
                        students.RemoveAt(NumberOfStudent);
                    }
                    else if (markMode == 1)
                    {
                        Console.Write("Выберите предмет из списка: ");
                        foreach (var _subject in subjects)
                        {
                            Console.Write(_subject+" ");
                        }

                        string subject = Console.ReadLine();
                        Console.Write("Выберите режим работы с оценками (1 - добавить, 0 - удалить): ");
                        

                    }
                }
            }
            Student.WriteStudents(students, fileName);
        }
    }
}
