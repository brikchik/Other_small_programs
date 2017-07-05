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
    public partial class Form3 : Form
    {
        bool editing = false;
        Group group;
        ListBox.ObjectCollection listboxitems;
        public Form3(ListBox.ObjectCollection listbox, ref Group g, bool edit)
        {
            InitializeComponent();
            editing = edit;
            listboxitems = listbox;
            if (!editing)g = new lab6_user_oriented_app.Group(0, "", 0, 0);
            if(editing)
            {
                Text = "Редактирование группы";
                numericUpDown2.Enabled = false;
                button1.Text = "Изменить";
            }
            group = g;
            Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (int o in listboxitems) if (o == numericUpDown2.Value) { textBox1.Text = "такая группа уже существует"; return; }
            if (textBox1.Text != "" && numericUpDown1.Value!=0 && numericUpDown2.Value!=0 && numericUpDown3.Value!=0)
            {
                if (!editing) group.number = (int)numericUpDown2.Value;
                group.faculty = textBox1.Text;
                group.study_year = (int)numericUpDown1.Value;
                group.students_count = (int)numericUpDown3.Value;
                this.Close();
            }
        }
    }
}
