using System;
using System.Windows.Forms;

namespace lab6_user_oriented_app
{
    public partial class Groups : Form
    {
        bool editing = false;
        Group group;
        ListBox.ObjectCollection listboxitems;
        public Groups(ListBox.ObjectCollection listbox, ref Group g, bool edit)
        {
            InitializeComponent();
            editing = edit;
            listboxitems = listbox;
            if (!editing)g = new lab6_user_oriented_app.Group(0, "", 0, 0);
            if(editing)
            {
                Text = "Edit group";
                numericUpDown2.Enabled = false;
                button1.Text = "Change";
            }
            group = g;
            Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (int o in listboxitems) if (o == numericUpDown2.Value) { textBox1.Text = "group exists/name not available"; return; }
            if (textBox1.Text != "" && numericUpDown1.Value!=0 && numericUpDown2.Value!=0 && numericUpDown3.Value!=0)
            {
                if (!editing) group.number = (int)numericUpDown2.Value;
                group.faculty = textBox1.Text;
                group.study_year = (int)numericUpDown1.Value;
                group.students_count = (int)numericUpDown3.Value;
                this.Close();
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Groups
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Groups";
            this.ResumeLayout(false);

        }
    }
}
