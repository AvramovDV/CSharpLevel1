using System;
using System.Collections.Generic;
using System.IO;

namespace Task2
{
    //Аврамов Д.В.

    //2. Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
    //а) Сделайте меню с различными функциями и предоставьте пользователю выбор, для какой функции и на каком отрезке находить минимум.
    //б) Используйте массив(или список) делегатов, в котором хранятся различные функции.
    //в) * Переделайте функцию Load, чтобы она возвращала массив считанных значений. Пусть она возвращает минимум через параметр.

    class Program
    {
        public delegate double MyFunction(double x);

        static void Main(string[] args)
        {
            MyFunction[] Functions = { F1, F2, F3, F4 };

            Console.WriteLine("Выбирите одну из функций: ");
            Console.WriteLine("1: x * x - 50 * x + 10");
            Console.WriteLine("2: 2 * x");
            Console.WriteLine("3: x * x * x");
            Console.WriteLine("4: x * x * x * x");

            int f = Int32.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("Введите начало отрезка: ");
            double a = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите конец отрезка: ");
            double b = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите шаг: ");
            double h = double.Parse(Console.ReadLine());

            SaveFunc("data.bin", Functions[f], a, b, h);

            double min;

            double[] d = Load("data.bin", out min);

            Console.WriteLine("Результат: ");
            
            for (int i = 0; i < d.Length; i++)
            {
                Console.WriteLine(d[i]);
            }

            Console.WriteLine($"Minimum = {min}");

            Console.ReadKey();

        }
                
                
        public static double F1(double x)
        {
            return x * x - 50 * x + 10;
        }

        public static double F2 (double x)
        {
            return 2 * x;
        }

        public static double F3(double x)
        {
            return x * x * x;
        }

        public static double F4(double x)
        {
            return x * x * x * x;
        }

        public static void SaveFunc(string fileName, MyFunction f, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(f(x));
                x += h;
            }
            bw.Close();
            fs.Close();
        }

        public static double[] Load(string fileName, out double min)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            min = double.MaxValue;
            double[] d = new double[fs.Length / sizeof(double)];
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                d[i] = bw.ReadDouble();
                if (d[i] < min) min = d[i];
            }
            bw.Close();
            fs.Close();
            return d;
        }

    }
}
