using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;
using System.IO;

namespace classwork091021
{
    class Student
    {
        public string firstName;
        public string lastName;
        int year;
        string exam;
        public Student()
        {
            Console.WriteLine("Введите имя");
            firstName = Console.ReadLine();
            Console.WriteLine("Введите фамилию");
            lastName = Console.ReadLine();
            Console.WriteLine("Введите год рождения");
            year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите экзамен");
            exam = Console.ReadLine();
        }
        public Student(string[] input)
        {
            firstName = input[0];
            lastName = input[1];
            year = Convert.ToInt32(input[2]);
            exam = input[3];
        }
        public override string ToString()
        {
            return firstName + " " + lastName + " " + year + " " + exam;
        }
    }
    class Program
    {
        static void NewStudent(Dictionary<int, Student> students)
        {
            Student newStudent = new Student();
            Console.WriteLine("Введите баллы");
            int score = Convert.ToInt32(Console.ReadLine());
            students.Add(score, newStudent);
        }
        static void Delete(Dictionary<int, Student> students)
        {
            Console.WriteLine("Введите имя");
            string firstName = Console.ReadLine();
            Console.WriteLine("Введите фамилию");
            string lastName = Console.ReadLine();
            foreach (KeyValuePair<int, Student> keyValue in students)
            {
                if ((keyValue.Value.firstName == firstName) && (keyValue.Value.lastName == lastName))
                {
                    students.Remove(keyValue.Key);
                }
            }
        }

        static void Sort(Dictionary<int, Student> students)
        {
            SortedDictionary<int, Student> sort = new SortedDictionary<int, Student>(students);
            students.Clear();
            foreach (KeyValuePair<int, Student> keyValue in sort)
            {
                Console.WriteLine(Convert.ToString(keyValue.Key) + " " + keyValue.Value);
                students.Add(keyValue.Key, keyValue.Value);
            }
        }

        static void Main(string[] args)
        {
            {
                Console.WriteLine("1.1");
                int[] bavaria = new int[] { 1, 2, 4, 5, 6, 7, 8, 5, 0 };
                int[] scandiv = new int[] { 3, 4, 5, 6, 7, 8, 0, 5, 1 };
                int quantitybav = 0; int quantityscand = 0;
                for (int i = 0; i < scandiv.Length; i++)
                {
                    if (bavaria[i] == 5)
                    {
                        quantitybav++;
                    }
                    if (scandiv[i] == 5)
                    {
                        quantityscand++;
                    }
                }
                if (quantitybav == quantityscand)
                {
                    Console.WriteLine("Drinks All Round!FreeBeeers on Bjorn!");
                }
                else
                {
                    Console.WriteLine("Ой,Бьорг-пончик!Ни для кого пива!");
                }

                //1.2
                Console.WriteLine("1.2");
                List<string> pictures = new List<string>()
            {
                @"folder\1.jpg",
                @"folder\1-копия.jpg",
                @"folder\2.jpg",
                @"folder\2-копия.jpg",
                @"folder\3.jpg",
                @"folder\3-копия.jpg",
                @"folder\4.jpg",
                @"folder\4-копия.jpg",
                @"folder\5.jpg",
                @"folder\5-копия.jpg",
                @"folder\6.jpg",
                @"folder\6-копия.jpg",
                @"folder\7.png",
                @"folder\7-копия.jpg",
                @"folder\8.jpg",
                @"folder\8-копия.jpg",
                @"folder\9.jpg",
                @"folder\9-копия.jpg",
                @"folder\10.jpg",
                @"folder\10-копия.jpg",
                @"folder\11.jpg",
                @"folder\11-копия.jpg",
                @"folder\12.jpg",
                @"folder\12-копия.jpg",
                @"folder\13.jpg",
                @"folder\13-копия.jpg",
                @"folder\14.jpg",
                @"folder\14-копия.jpg",
                @"folder\15.jpg",
                @"folder\15-копия.jpg",
                @"folder\16.jpg",
                @"folder\16-копия.jpg",
                @"folder\17.jpg",
                @"folder\17-копия.jpg",
                @"folder\18.jpg",
                @"folder\18-копия.jpg",
                @"folder\19.jpg",
                @"folder\19-копия.jpg",
                @"folder\20.jpg",
                @"folder\20-копия.jpg",
                @"folder\21.jpg",
                @"folder\21-копия.jpg",
                @"folder\22.jpg",
                @"folder\22-копия.jpg",
                @"folder\23.jpg",
                @"folder\23-копия.jpg",
                @"folder\24.jpg",
                @"folder\24-копия.jpg",
                @"folder\25.jpg",
                @"folder\25-копия.jpg",
                @"folder\26.jpg",
                @"folder\26-копия.jpg",
                @"folder\27.jpg",
                @"folder\27-копия.jpg",
                @"folder\28.jpg",
                @"folder\28-копия.jpg",
                @"folder\29.jpg",
                @"folder\29-копия.jpg",
                @"folder\30.jpg",
                @"folder\30-копия.jpg",
                @"folder\31.jpg",
                @"folder\31-копия.jpg",
                @"folder\32.jpg",
                @"folder\32-копия.jpg"
            };
                Console.WriteLine("\n не перемешанный:\n" + String.Join("\n", pictures));
                for (int i = 0; i < pictures.Count; i++)
                {
                    Random rnd = new Random();
                    int numodd = rnd.Next(pictures.Count);
                    Swap(pictures, i, numodd, pictures[i], pictures[numodd]);
                }
                Console.WriteLine("\n Перемешанный:\n" + String.Join("\n", pictures));

                //1.3
                Console.WriteLine("1.3");
                Console.WriteLine("Задание 3");
                Dictionary<int, Student> students = new Dictionary<int, Student>(10);
                StreamReader reader = new StreamReader("input.txt");
                string[] input = reader.ReadToEnd().Split('\n');
                for (int i = 0; i < input.Length; i++)
                {
                    string[] studentData = input[i].Split();
                    Student newStudent = new Student(studentData);
                    int score = Convert.ToInt32(studentData[studentData.Length - 1]);
                    students.Add(score, newStudent);
                }
                bool flag = true;
                while (flag)
                {
                    Console.WriteLine("Введите команду");
                    string instruction = Console.ReadLine();
                    switch (instruction)
                    {
                        case "Новый студент":
                            NewStudent(students);
                            break;
                        case "Удалить":
                            Delete(students);
                            break;
                        case "Сортировать":
                            Sort(students);
                            break;
                        case "Выход":
                            flag = false;
                            break;
                        default:
                            break;
                    }
                }
            }



        }
        static void Swap(List<String> array, int i1, int i2, string value1, string value2)
        {
            array[i1] = value1;
            array[i2] = value2;
        }
    } 
}


    

