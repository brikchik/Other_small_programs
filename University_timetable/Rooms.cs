using System;
using System.Windows.Forms;

namespace lab6_user_oriented_app
{
    public partial class Rooms : Form
    {
        ListBox.ObjectCollection listboxitems;
        bool editing = false;
        Room room;
        public Rooms(ListBox.ObjectCollection listbox, ref Room r, bool edit)
        {
            InitializeComponent();
            editing = edit;
            listboxitems = listbox;
            if(!editing)r = new Room(0, 0, 0);
            if (editing)
            {
                Text = "Edit room";
                numericUpDown2.Enabled = false;
                button1.Text = "Change";
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
