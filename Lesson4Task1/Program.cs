using System;


namespace Lesson4Task1
{
    //Аврамов Д.В.

    //1. Дан целочисленный массив из 20 элементов.Элементы массива могут принимать целые значения от –10 000 до 10 000 включительно.
    //Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых хотя бы одно число делится на 3. 
    //В данной задаче под парой подразумевается два подряд идущих элемента массива.
    //Например, для массива из пяти элементов: 6; 2; 9; –3; 6 – ответ: 4.

    //2. а) Дописать класс для работы с одномерным массивом.
    //Реализовать конструктор, создающий массив заданной размерности и заполняющий массив числами от начального значения с заданным шагом.
    //Создать свойство Sum, которые возвращают сумму элементов массива, 
    //метод Inverse, меняющий знаки у всех элементов массива, 
    //метод Multi, умножающий каждый элемент массива на определенное число,
    //свойство MaxCount, возвращающее количество максимальных элементов.В Main продемонстрировать работу класса.
    //б)Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.

    //3. Решить задачу с логинами из предыдущего урока, только логины и пароли считать из файла в массив. Создайте структуру Account, содержащую Login и Password.

    //4. *а) Реализовать класс для работы с двумерным массивом.
    //Реализовать конструктор, заполняющий массив случайными числами.
    //Создать методы, которые возвращают сумму всех элементов массива, сумму всех элементов массива больше заданного, свойство, возвращающее минимальный элемент массива,
    //свойство, возвращающее максимальный элемент массива, метод, возвращающий номер максимального элемента массива(через параметры, используя модификатор ref или out)
    //* б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
    
    // Дополнительные задачи
    //в) Обработать возможные исключительные ситуации при работе с файлами.

    class Program
    {
        static void Main(string[] args)
        {
            //Task1();
            //Task2();
            Task4();
        }

        public static void Task1()
        {
            int count = 0;
            int[] mass = new int[20];

            Random _random = new Random();

            for (int i = 0; i < mass.Length; i++)
            {
                mass[i] = _random.Next(-10000, 10000);
            }

            for (int i = 0; i < mass.Length - 1; i++)
            {
                if (mass[i] % 3 == 0 || mass[i + 1] % 3 == 0)
                {
                    count++;
                }
            }

            
            Console.WriteLine($"Ответ: {count}");
            Console.ReadLine();
        }

        public static void Task2()
        {
            MyArray1D myArray = new MyArray1D(10, 1, 1);

            Console.WriteLine(myArray.ToString());

            Console.WriteLine($"Количество максимальных элементов: {myArray.MaxCount}");

            Console.WriteLine($"Сумма элементов массива: {myArray.Sum}");

            myArray.Multi(2);

            Console.WriteLine($"2x: {myArray.ToString()}");

            myArray.Inverse();

            Console.WriteLine($"Inverse: {myArray.ToString()}");

            myArray.FileWrite("Task1");

            myArray = new MyArray1D("Task1");

            Console.WriteLine(myArray.ToString());

            Console.ReadLine();
        }

        public static void Task4()
        {
            MyArray2D myArray = new MyArray2D(5, 5);

            Console.WriteLine(myArray.ToString());

            Console.WriteLine($"Сумма всех элементов: {myArray.SumOfAll()}");

            Console.WriteLine($"Сумма всех элементов больше 50: {myArray.SumOfGreaterThan(50)}");

            Console.WriteLine($"Минимальное число : {myArray.Min}");

            Console.WriteLine($"Максимальное число: {myArray.Max}");

            myArray.WriteFile("Task4.txt");

            myArray = new MyArray2D("Task4.txt");

            Console.WriteLine(myArray.ToString());

            Console.ReadLine();
        }
        
    }
}
