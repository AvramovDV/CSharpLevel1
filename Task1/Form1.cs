using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    //Аврамов Д.В.

    //а) Добавить в программу «Удвоитель» подсчёт количества отданных команд удвоителю.
    //б) Добавить меню и команду «Играть». При нажатии появляется сообщение, какое число должен получить игрок.
    //   Игрок должен получить это число за минимальное количество ходов.
    //в) * Добавить кнопку «Отменить», которая отменяет последние ходы. Используйте обобщенный класс Stack.
    // Вся логика игры должна быть реализована в классе с удвоителем.

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int _number = 0;
        private int _count = 0;

        private class Mydata
        {
            public int Number;
            public int Count;

            public Mydata(int number = 0, int count = 0)
            {
                Number = number;
                Count = count;
            }
        }

        private Mydata _victoryCondition;

        private Stack<Mydata> _stack = new Stack<Mydata>();

        private void buttonPlusOne_Click(object sender, EventArgs e)
        {
            _stack.Push(new Mydata(_number, _count));
            _number++;
            _count++;
            labelResult.Text = _number.ToString();
            labelCount.Text = $"Количество команд: {_count}";
            VictoryCheck();
        }

        private void buttonMultiplyByTwo_Click(object sender, EventArgs e)
        {
            _stack.Push(new Mydata(_number, _count));
            _number = _number * 2;
            _count++;            
            labelResult.Text = _number.ToString();
            labelCount.Text = $"Количество команд: {_count}";
            VictoryCheck();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            _stack.Push(new Mydata(_number, _count));
            _number = 0;
            _count = 0;
            labelResult.Text = _number.ToString();
            labelCount.Text = $"Количество команд: {_count}";
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (_stack.Count == 0)
            {
                return;
            }
            Mydata current = _stack.Pop();
            _number = current.Number;
            _count = current.Count;
            labelResult.Text = _number.ToString();
            labelCount.Text = $"Количество команд: {_count}";
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int res = rand.Next(3, 100);
            int a = res;
            int count = 0;
            while (a > 1)
            {
                count = count + 1 + a % 2;
                a /= 2;
            }
            count++;
            labelCondition.Text = $"Получите число {res} за {count} ходов";
            _victoryCondition = new Mydata(res, count);
            buttonReset_Click(buttonCancel, EventArgs.Empty);
            
        }

        private void VictoryCheck()
        {
            if (_victoryCondition != null)
            {
                if (_count <= _victoryCondition.Count && _number == _victoryCondition.Number)
                {
                    MessageBox.Show("Вы победили!");
                    buttonReset_Click(buttonCancel, EventArgs.Empty);
                    labelCondition.Text = "";
                    _victoryCondition = null;
                }
                else if (_count > _victoryCondition.Count) 
                {
                    MessageBox.Show("Вы проиграли!");
                    buttonReset_Click(buttonCancel, EventArgs.Empty);
                    labelCondition.Text = "";
                    _victoryCondition = null;
                }
            }
            
        }
    }
}
