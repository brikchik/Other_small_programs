using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab6_user_oriented_app
{
    public partial class Form1 : Form
    {
        Timetable TT;
        public Form1()
        {
            InitializeComponent();
            TT = new Timetable(richTextBox1, listBox1, listBox2, listBox3, dateTimePicker1);
            TT.addSomeValues();//random values for demo
            TT.updateComponents();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TT.showLB1();
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            TT.showLB2();
        }
        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            TT.showLB3();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            TT.updateComponents();
            richTextBox1.Text = "Текущее расписание:\n";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Array.Resize(ref TT.groups, TT.groups.Count() + 1);
            new Form3(listBox1.Items, ref TT.groups[TT.groups.Count() - 1],false);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Array.Resize(ref TT.lessons, TT.lessons.Count() + 1);
            new Form2(listBox2.Items,ref TT.lessons[TT.lessons.Count() - 1],false);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Array.Resize(ref TT.rooms, TT.rooms.Count() + 1);
            new Form4(listBox3.Items, ref TT.rooms[TT.rooms.Count() - 1],false);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            new Form3(listBox1.Items, ref TT.groups[listBox1.SelectedIndex],true);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            new Form4(listBox3.Items, ref TT.rooms[listBox3.SelectedIndex], true);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            new Form2(listBox2.Items,ref TT.lessons[listBox2.SelectedIndex],true);
        }
        private void label2_Click(object sender, EventArgs e){ }

        private void updateComponents(object sender, EventArgs e)
        {
            TT.updateComponents();// При любом переключении на форму (например, после закрытия доп.окон)
        }
    }
}