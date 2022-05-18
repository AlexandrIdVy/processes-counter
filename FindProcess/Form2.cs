using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FindProcess
{
    public partial class Form2 : Form
    {        
        string pathMaxProcess = "MaxProcess.txt"; // файл максимальное кол-во процессов всего
        public Form2()
        {
            InitializeComponent();
        }       

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {                
                e.Handled = true;                              
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Значение не введено!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
            else
            {
                if (Convert.ToInt32(textBox1.Text) > Convert.ToInt32(File.ReadAllLines(pathMaxProcess, Encoding.UTF8).First()))
                {
                    MessageBox.Show("Введенное количество процессов больше нормы!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                }
            }  
        }        
    }
}
