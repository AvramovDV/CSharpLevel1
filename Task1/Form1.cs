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

    //1. а) Создать приложение, показанное на уроке, добавив в него защиту от возможных ошибок
    //(не создана база данных, обращение к несуществующему вопросу, открытие слишком большого файла и т.д.).
    //б) Изменить интерфейс программы, увеличив шрифт, поменяв цвет элементов и др. на свое усмотрение.
    //в) Добавить в приложение меню «О программе» с информацией о программе(автор, версия, авторские права и др.).
    //г) Добавить в приложение сообщение с предупреждением при попытке удалить вопрос.
    //д) Добавить пункт меню Save As, в котором можно выбрать имя для сохранения базы данных(элемент SaveFileDialog).

    public partial class Form1 : Form
    {
        private TrueFalse _dataBase;

        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                _dataBase = new TrueFalse(sfd.FileName);
                _dataBase.Add("123", true);
                _dataBase.Save();
                numericUpDown.Minimum = 1;
                numericUpDown.Maximum = 1;
                numericUpDown.Value = 1;
            };
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _dataBase = new TrueFalse(ofd.FileName);
                _dataBase.Load();
                numericUpDown.Minimum = 1;
                numericUpDown.Maximum = _dataBase.Count;
                numericUpDown.Value = 1;
            }
            
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_dataBase != null) _dataBase.Save();
            else MessageBox.Show("База данных не создана");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (_dataBase == null)
            {
                MessageBox.Show("Создайте новую базу данных", "Сообщение");
                return;
            }
            _dataBase.Add((_dataBase.Count + 1).ToString(), true);
            numericUpDown.Maximum = _dataBase.Count;
            numericUpDown.Value = _dataBase.Count;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (numericUpDown.Maximum == 1 || _dataBase == null) return;

            DialogResult res = MessageBox.Show("Вопрос будет удален из базы. Продолжить?", "Внимание", MessageBoxButtons.OKCancel);

            if (res == DialogResult.Cancel) return;
            
            _dataBase.Remove((int)numericUpDown.Value);
            numericUpDown.Maximum--;
            if (numericUpDown.Value > 1) numericUpDown.Value = numericUpDown.Value;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (_dataBase == null)
            {
                MessageBox.Show("Создайте новую базу данных", "Сообщение");
                return;
            }
            _dataBase[(int)numericUpDown.Value - 1].Text = textBox.Text;
            _dataBase[(int)numericUpDown.Value - 1].TrueFalse = checkBoxTrue.Checked;
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            textBox.Text = _dataBase[(int)numericUpDown.Value - 1].Text;
            checkBoxTrue.Checked = _dataBase[(int)numericUpDown.Value - 1].TrueFalse;
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("QuestionEditor \n v1.0 \n autor: GeekBrains \n all rights reserved", "About");
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_dataBase == null)
            {
                MessageBox.Show("База данных не создана");
            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog();
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    _dataBase.Save(sfd.FileName);
                    
                }
            }
           
        }
    }
}
