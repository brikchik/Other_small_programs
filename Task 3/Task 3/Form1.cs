using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_3
{
    public partial class Form1 : Form
    {
        MessageStack a = new MessageStack(1);
        MessageStack b = new MessageStack(1);
        MessageStack current;
        Message currM;
        public Form1()
        {
            InitializeComponent();
            listBox1.Items.Add("Стек 1");
            listBox1.Items.Add("Стек 2");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            current = a;
            currM = current.peek();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = ""+currM.getNumber();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "" + currM.getDate();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "" + currM.getMessage();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "" + currM.getFullMessage();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currM.setDate(dateTimePicker1.Value);//ввод не свободный, исключений не будет
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value < 0) richTextBox1.Text = "Номер должен быть целым положительным числом!";else
            currM.setNumber((uint)numericUpDown1.Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            currM.setMessage(textBox1.Text);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 0) current = a; else current = b;
            if(!current.isEmpty())currM = current.peek();else richTextBox1.Text = "Ошибка открытия стека";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if(!(a & b))richTextBox1.Text="Ошибка копирования стека 2 в стек 1";
            current = a;
            currM = current.peek();
            listBox1.SelectedIndex = 0;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Message x = new Task_3.Message();
            current.push(x);
            currM = current.peek();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!(current.getSize()==1)) { current.pop(); currM = current.peek(); }
            else { richTextBox1.Text = "стек пуст"; };
        }
    }
}
