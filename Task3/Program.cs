using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    //Аврамов Д.В.

    //Переделать программу Пример использования коллекций для решения следующих задач:
    //а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
    //б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся(*частотный массив);
    //в) отсортировать список по возрасту студента;
    //г) * отсортировать список по курсу и возрасту студента;
    //д) разработать единый метод подсчета количества студентов по различным параметрам
    //выбора с помощью делегата и методов предикатов.

    class Program
    {
        public static int MinAge = 18;
        public static int MaxAge = 20;
        public static int CurrentCourse = 1;

        static void Main(string[] args)
        {
            string _file = "students_1.csv";

            List<Student> list = new List<Student>();

            StreamReader sr = new StreamReader(_file);

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();

                list.Add(new Student(line));
                
            }

            sr.Close();

            Console.WriteLine($"Общее количество студентов: {list.Count}");

            Console.WriteLine($"Количество студентов от 18 до 20 лет : {list.FindAll(AgeFilter).Count}");

            CurrentCourse = 5;
            Console.WriteLine($"Количество студентов, учащихся на 5 курсе: {list.FindAll(CourseFilter).Count}");

            CurrentCourse = 6;
            Console.WriteLine($"Количество студентов, учащихся на 6 курсе: {list.FindAll(CourseFilter).Count}");

            List<Student> listByAge = list.FindAll(AgeFilter);

            int[] courseFriquency = new int[6];

            for (int i = 0; i < 6; i++)
            {
                CurrentCourse = i + 1;
                courseFriquency[i] = listByAge.FindAll(CourseFilter).Count;
                Console.WriteLine($"Количество студентов от 18 до 20 лет на {i + 1} курсе: {courseFriquency[i]}");
            }

            list.Sort(MyComporisonByAge);//сортировка по возрасту
                                          
            list.Sort(MyComporisonByCourseAndAge);//сортировка по курсу и возрасту (сортировка по курсу, в пределах каждого курса по возрасту)
                        
            Console.ReadKey();
        }

        public static bool AgeFilter(Student s) { return s.Age >= MinAge && s.Age <= MaxAge; }

        public static bool CourseFilter(Student s) { return s.Course == CurrentCourse; }

        public static int MyComporisonByAge(Student a, Student b) { return a.Age.CompareTo(b.Age); }

        public static int MyComporisonByCourse(Student a, Student b) { return a.Course.CompareTo(b.Course); }

        public static int MyComporisonByCourseAndAge(Student a, Student b)
        {
            int course = a.Course.CompareTo(b.Course);

            int age = a.Age.CompareTo(b.Age);

            if (course == 0)
            {
                return age;
            }
            else
            {
                return course;
            }
                        
        }
                       
    }

    public class Student
    {
        public string FirstName;
        public string SecondName;
        public string Univercity;
        public string Faculty;
        public string Department;
        public int Age;
        public int Course;
        public int Group;
        public string City;

        public Student(string line)
        {
            string[] values = line.Split(';');
            FirstName = values[0];
            SecondName = values[1];
            Univercity = values[2];
            Faculty = values[3];
            Department = values[4];
            Age = Int32.Parse(values[5]);
            Course = Int32.Parse(values[6]);
            Group = Int32.Parse(values[7]);
            City = values[8];
        }

    }


}
