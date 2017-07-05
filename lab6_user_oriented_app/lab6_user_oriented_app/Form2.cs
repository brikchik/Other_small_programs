using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace lab6_user_oriented_app
{
    public partial class Form2 : Form
    {
        bool editing = false;
        Lesson lesson;
        ListBox.ObjectCollection listboxitems;
        public Form2(ListBox.ObjectCollection listbox,ref Lesson l, bool edit)
        {
            if(!edit)l = new Lesson(true, "", "", 0);
            lesson = l;
            listboxitems = listbox;
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Time;
            dateTimePicker2.Format = DateTimePickerFormat.Time;
            if (editing)
            {
                Text = "Редактирование занятия";
                numericUpDown2.Enabled = false;
                button1.Text = "Изменить";
            }
            button1.Enabled = false;
            this.Show();
            lesson.lection = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            lesson.lection = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (string o in listboxitems) if (o == textBox1.Text) { textBox1.Text = "имя занято"; return; }
            if (dateTimePicker2.Value > dateTimePicker1.Value && textBox2.Text!="" && numericUpDown1.Value!=0 
                && numericUpDown2.Value!=0)
            {
                if (!editing) lesson.name = textBox1.Text;
                lesson.faculty = textBox2.Text;
                lesson.roomNumber = (int)numericUpDown2.Value;
                lesson.study_year = (int)numericUpDown1.Value;
                lesson.time.start = dateTimePicker1.Value;
                lesson.time.end = dateTimePicker2.Value;
                if (radioButton1.Checked) lesson.oddPara = 0;
                else
                if (radioButton2.Checked) lesson.oddPara = 1;
                else
                if (radioButton3.Checked) lesson.oddPara = 2;
                ArrayList x = new ArrayList();
                if (numericUpDown3.Value != 0 && x.Contains((int)numericUpDown3.Value)) x.Add((int)numericUpDown3.Value);
                if (numericUpDown4.Value != 0 && x.Contains((int)numericUpDown4.Value)) x.Add((int)numericUpDown4.Value);
                if (numericUpDown5.Value != 0 && x.Contains((int)numericUpDown5.Value)) x.Add((int)numericUpDown5.Value);
                if (numericUpDown6.Value != 0 && x.Contains((int)numericUpDown6.Value)) x.Add((int)numericUpDown6.Value);
                lesson.groups = new int[x.Count];
                for (int i = 0; i < x.Count; i++) lesson.groups[i] = (int)x[i];
                this.Close();
            }         
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "") button1.Enabled = true; else button1.Enabled = false;
        }
    }
}
