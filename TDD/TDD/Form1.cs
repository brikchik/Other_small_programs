using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace TDD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private tdd press;
        private void Form1_Load(object sender, EventArgs e)
        {
            press = new TDD.tdd();//наш датчик

        }

        private void currentButton_Click(object sender, EventArgs e)
        {
            if (!press.set_current(currentBox.Text))successLabel.Text="Ошибка!";
            else successLabel.Text = "Ток успешно задан";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tdd a=new tdd();tdd b=new tdd();a.set_current(5);b.set_current(8);
            textBox1.Text = press.get_full_pressure()+(a<b);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
