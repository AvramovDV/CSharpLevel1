using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    //Используя Windows Forms, разработать игру «Угадай число».
    //Компьютер загадывает число от 1 до 100, а человек пытается его угадать за минимальное число попыток.
    //Компьютер говорит, больше или меньше загаданное число введенного.
    //a) Для ввода данных от человека используется элемент TextBox;
    //б) ** Реализовать отдельную форму c TextBox для ввода числа.

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Start();
        }

        private int _number;

        private int _count = 6;

        private void Start()
        {
            Random rand = new Random();
            _number = rand.Next(1, 100);
            _count = 6;
            labelInfo.Text = $"Угадайте число от 1 до 100";
        }
                
        private void textBoxAnswer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            if (_count == 0)
            {
                Start();
                return;
            }

            int answer = Int32.Parse(textBoxAnswer.Text);

            if (answer < _number)
            {
                _count--;
                labelInfo.Text = $"Ваше число {answer} слишком мало. Нужно больше. Осталось попыток: {_count}.";
            }
            else if (answer > _number)
            {
                _count--;
                labelInfo.Text = $"Ваше число {answer} слишком велико. Нужно меньше. Осталось попыток: {_count}.";
            }
            else
            {
                labelInfo.Text = $"Вы угадали: {_number}!";
                MessageBox.Show($"Вы угадали: {_number}!");
                Start();
                return;
            }

            if (_count == 0)
            {
                labelInfo.Text = $"Вы проиграли. Правильный ответ: {_number}!";
                                
            }
        }
    }
}
