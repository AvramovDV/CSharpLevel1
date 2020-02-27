using System;
using System.IO;


namespace Lesson4Task1
{
    //4. *а) Реализовать класс для работы с двумерным массивом.
    //Реализовать конструктор, заполняющий массив случайными числами.
    //Создать методы, которые возвращают сумму всех элементов массива, сумму всех элементов массива больше заданного, 
    //свойство, возвращающее минимальный элемент массива,
    //свойство, возвращающее максимальный элемент массива,
    //метод, возвращающий номер максимального элемента массива(через параметры, используя модификатор ref или out)
    //* б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.

    public class MyArray2D
    {
        private int[,] array;

        public MyArray2D(int sizeX, int sizeY)
        {
            array = new int[sizeX, sizeY];

            Random rnd = new Random();

            for (int i = 0; i < sizeY; i++)
            {
                for (int j = 0; j < sizeX; j++)
                {
                    array[j, i] = rnd.Next(0, 100);
                }
            }
        }

        public MyArray2D(string filename)
        {
            if (!File.Exists(filename))
            {
                return;
            }

            string[] arrows = File.ReadAllLines(filename);
            string[] colomns = arrows[0].Split(' ');

            array = new int[colomns.Length, arrows.Length];

            for (int i = 0; i < array.GetLength(1); i++)
            {
                string[] a = arrows[i].Split(' ');

                for (int j = 0; j < array.GetLength(0); j++)
                {
                    int.TryParse(a[j], out array[j, i]);
                }
            }

        }

        public int SumOfAll()
        {
            int sum = 0;

            for (int i = 0; i < array.GetLength(1); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    sum += array[j, i];
                }
            }

            return sum;
        }

        public int SumOfGreaterThan(int border)
        {
            int sum = 0;

            for (int i = 0; i < array.GetLength(1); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    if(array[j, i] > border) sum += array[j, i];
                }
            }

            return sum;
        }

        public int Min
        {
            get
            {
                int min = array[0, 0];

                for (int i = 0; i < array.GetLength(1); i++)
                {
                    for (int j = 0; j < array.GetLength(0); j++)
                    {
                        if (array[j, i] < min) min = array[j, i];
                    }
                }

                return min;
            }
        }

        public int Max
        {
            get
            {
                int max = array[0, 0];

                for (int i = 0; i < array.GetLength(1); i++)
                {
                    for (int j = 0; j < array.GetLength(0); j++)
                    {
                        if (array[j, i] > max) max = array[j, i];
                    }
                }

                return max;
            }
        }

        public override string ToString()
        {
            string res = "";

            for (int i = 0; i < array.GetLength(1); i++)
            {

                for (int j = 0; j < array.GetLength(0); j++)
                {
                    if(j == 0) res += $"{array[j, i].ToString()}";
                    else res += $" {array[j, i].ToString()}";
                }

                res += "\n";
            }
            return res;
        }

        public void WriteFile(string filename)
        {
            File.WriteAllText(filename, this.ToString());
        }

        public void ReadFile(string filename)
        {
            if (!File.Exists(filename))
            {
                return;
            }

            string[] arrows = File.ReadAllLines(filename);
            string[] colomns = arrows[0].Split(' ');

            array = new int[colomns.Length, arrows.Length];

            for (int i = 0; i < array.GetLength(1); i++)
            {
                string[] a = arrows[i].Split(' ');

                for (int j = 0; j < array.GetLength(0); j++)
                {
                    array[j, i] = int.Parse(a[j]);
                }
            }
        }

    }
}
