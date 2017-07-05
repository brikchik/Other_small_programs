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
    public partial class Form4 : Form
    {
        ListBox.ObjectCollection listboxitems;
        bool editing = false;
        Room room;
        public Form4(ListBox.ObjectCollection listbox, ref Room r, bool edit)
        {
            InitializeComponent();
            editing = edit;
            listboxitems = listbox;
            if(!editing)r = new Room(0, 0, 0);
            if (editing)
            {
                Text = "Редактирование аудитории";
                numericUpDown2.Enabled = false;
                button1.Text = "Изменить";
            }
            room = r;
            this.Show();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (int o in listboxitems)if (o == numericUpDown2.Value) { return; }
            if (numericUpDown1.Value != 0 && numericUpDown2.Value != 0 && numericUpDown3.Value != 0)
            {
                room.building = (int)numericUpDown2.Value;
                if (!editing) room.number = (int)numericUpDown1.Value;
                room.chairs = (int)numericUpDown3.Value;
                this.Close();
            }
        }
    }
}
