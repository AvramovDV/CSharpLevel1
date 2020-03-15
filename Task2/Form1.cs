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

    //Аврамов Д. В.

    //2. Используя полученные знания и класс TrueFalse, разработать игру «Верю — не верю».

    public partial class BeliveMe : Form
    {
        private TrueFalse _dataBase;

        private int count = 0;

        public BeliveMe()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _dataBase = new TrueFalse(ofd.FileName);
                _dataBase.Load();
                StartGame();
            }

        }

        private void StartGame()
        {
            count = 0;
            for (int i = 0; i < _dataBase.Count; i++)
            {
                DialogResult res = MessageBox.Show($" Правда ли то, что {_dataBase[i].Text}", $"Викторина вопрос {i + 1}", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                bool r = res == DialogResult.Yes ? true : false; 
                if (r == _dataBase[i].TrueFalse)
                {
                    MessageBox.Show("Правильно");
                    count++;
                }
                else
                {
                    MessageBox.Show("Неправильно");
                }
            }
            MessageBox.Show($"Конец вы дали {count} правильных ответов из {_dataBase.Count}");
        }
    }
}
