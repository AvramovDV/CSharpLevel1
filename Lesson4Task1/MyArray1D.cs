using System.IO;

namespace Lesson4Task1
{
    //2. а) Дописать класс для работы с одномерным массивом.
    //Реализовать конструктор, создающий массив заданной размерности и заполняющий массив числами от начального значения с заданным шагом.
    //Создать свойство Sum, которые возвращают сумму элементов массива, 
    //метод Inverse, меняющий знаки у всех элементов массива,
    //метод Multi, умножающий каждый элемент массива на определенное число,
    //свойство MaxCount, возвращающее количество максимальных элементов.
    //В Main продемонстрировать работу класса.
    //б)Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.

    public class MyArray1D
    {
        private int[] array;

        public MyArray1D(int size, int startValue, int step)
        {
            array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = startValue + i * step;
            }
        }

        public MyArray1D(string filename)
        {
            if (!File.Exists(filename))
            {
                return;
            }

            string[] str = File.ReadAllLines(filename);

            array = new int[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                array[i] = int.Parse(str[i]);
            }
        }

        public int Sum
        {
            get
            {
                int sum = 0;

                for (int i = 0; i < array.Length; i++)
                {
                    sum += array[i];
                }

                return sum;
            }
        }

        public void Inverse()
        {
            

            for (int i = 0; i < array.Length; i++)
            {
                array[i] *= -1;
            }

           
        }

        public void Multi(int value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] *= value;
            }
        }

        public int MaxCount
        {
            get
            {
                int max = array[0];

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] > max)
                    {
                        max = array[i];
                    }
                }

                int count = 0;

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == max)
                    {
                        count++;
                    }
                }

                return count;
            }
        }

        public void FileWrite(string filename)
        {
            string[] str = new string[array.Length];

            for (int i = 0; i < str.Length; i++)
            {
                str[i] = array[i].ToString();
            }

            File.WriteAllLines(filename, str);
        }

        public void FileRead(string filename)
        {
            if (!File.Exists(filename))
            {
                return;
            }

            string[] str = File.ReadAllLines(filename);

            array = new int[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                array[i] = int.Parse(str[i]);
            }
        }

        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < array.Length; i++)
            {
                res += $" {array[i]}";
            }
            return res;
        }

    }
}
