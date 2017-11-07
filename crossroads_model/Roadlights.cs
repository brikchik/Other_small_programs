using System;
using System.Windows.Forms;

namespace Crossroads_model
{
    public partial class Roadlights : Form
    {
        roadlight Thing;
        public Roadlights(roadlight rl,int n)
        {
            InitializeComponent();
            Thing = rl;
            if (rl.GetType() == (new ped_roadlight(0)).GetType())
            {
                listBox2.Items.RemoveAt(2);//no yellow
                listBox3.Items.RemoveAt(2);
                listBox4.Items.RemoveAt(2);
                listBox5.Items.RemoveAt(2);
            }
            pictureBox1.Image = Thing.pic;
            label1.Text = "" + n;
        }

        private void Roadlight_Load(object sender, EventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void Roadlights_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Thing.state = listBox1.SelectedIndex;
            int[] mode= { Thing.state, Thing.state, Thing.state, Thing.state, Thing.state };
            Thing.setProgram(mode);
            refresh();
        }
        private void refresh()
        {
            Thing.paint();
            pictureBox1.Image = Thing.pic;
        }
        private int[] program = { 0,0,0,0};//program for roadlight
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            program[0] = listBox2.SelectedIndex;
            program[1] = listBox3.SelectedIndex;
            program[2] = listBox4.SelectedIndex;
            program[3] = listBox5.SelectedIndex;
            Thing.setProgram(program);
            refresh();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}